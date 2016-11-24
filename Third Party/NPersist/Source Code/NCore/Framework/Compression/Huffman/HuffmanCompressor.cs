// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.IO;

namespace Puzzle.NCore.Framework.Compression
{
    public class HuffmanCompressor : ICompressor
    {
        private int[] occurences = new int[256];
        private ArrayList flatNodes = new ArrayList();
        private ArrayList nodes = new ArrayList();
        private HuffmanNode rootNode = null;

        private MemoryStream stream = new MemoryStream();


        public HuffmanCompressor()
        {
        }

        public byte[] Compress(byte[] data)
        {
            FillOccurences(data);
            BuildNodes();
            BuildNodeTree();
            BuildNodeMasks();
            StoreHuffmanTree();

            return HuffmanCompress(data);
        }

        private void StoreHuffmanTree()
        {
            for (int i = 0; i < 256; i++)
            {
                HuffmanNode node = (HuffmanNode) nodes[i];
                byte[] bytes = BitConverter.GetBytes(node.Occurrences);
                stream.Write(bytes, 0, 4);
            }
        }

        private byte[] HuffmanCompress(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int current = data[i];
                HuffmanNode node = (HuffmanNode) nodes[current];
                WriteBits(node.BitMask, node.BitCount);
            }
            FlushByte();
            stream.WriteByte((byte) bufferBytePos);

            byte[] compressedBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(compressedBytes, 0, compressedBytes.Length);
            return compressedBytes;
        }

        private void WriteBits(int bits, int count)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                int andMask = 1 << i;

                int bit = (bits & andMask) >> (i);

                WriteBit(bit);
            }
        }

        private void FlushByte()
        {
            if (bufferBytePos != 7)
                stream.WriteByte(bufferByte);
        }

        private int bufferBytePos = 7;
        private byte bufferByte = 0;

        private void WriteBit(int bit)
        {
            bufferByte |= (byte) (bit << bufferBytePos);
            bufferBytePos --;

            if (bufferBytePos == -1)
            {
                FlushByte();
                bufferBytePos = 7;
                bufferByte = 0;
            }
        }

        private void BuildNodeMasks()
        {
            BuildNodeMask(rootNode, 0, 0);
        }

        private void BuildNodeMask(HuffmanNode node, int lastMask, int bits)
        {
            if (node == null)
                return;

            if (node.Occurrences == 0)
                return;


            node.BitMask = (lastMask << 1) | node.Bit;
            bits ++;
            node.BitCount = bits;

            BuildNodeMask(node.LeftNode, node.BitMask, node.BitCount);
            BuildNodeMask(node.RightNode, node.BitMask, node.BitCount);
        }


        private void BuildNodeTree()
        {
            while (flatNodes.Count > 1)
            {
                SortFlatNodes();

                HuffmanNode a = flatNodes[0] as HuffmanNode;
                HuffmanNode b = flatNodes[1] as HuffmanNode;

                HuffmanNode c = new HuffmanNode();
                c.IsLeaf = false;
                c.Occurrences = a.Occurrences + b.Occurrences;
                c.LeftNode = a;
                c.RightNode = b;
                a.Bit = 0;
                b.Bit = 1;
                flatNodes.RemoveAt(0);
                flatNodes.RemoveAt(0);
                flatNodes.Add(c);
            }

            rootNode = flatNodes[0] as HuffmanNode;
        }


        private void SortFlatNodes()
        {
            flatNodes.Sort(new HuffmanNodeComparer());
        }

        private void BuildNodes()
        {
            for (int i = 0; i <= 255; i++)
            {
                int currentOccurences = occurences[i];

                HuffmanNode node = new HuffmanNode();
                node.Data = (byte) i;
                node.Occurrences = currentOccurences;

                flatNodes.Add(node);

                nodes.Add(node);
            }
        }

        private void FillOccurences(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                occurences[data[i]]++;
            }
        }

        public byte[] Decompress(byte[] bytes)
        {
            nodes.Clear();
            for (int i = 0; i < 256; i++)
            {
                int occurence = BitConverter.ToInt32(bytes, i*4);
                occurences[i] = occurence;
            }
            nodes = new ArrayList();
            flatNodes = new ArrayList();
            rootNode = null;
            BuildNodes();
            BuildNodeTree();
            BuildNodeMasks();


            MemoryStream data = new MemoryStream(bytes, 256*4, bytes.Length - 256*4);

            data.Position = data.Length - 1;
            int endBufferPos = data.ReadByte();

            data.Position = 0;
            MemoryStream result = new MemoryStream();
            int bufferPos = -1;

            int currentByte = 0;
            HuffmanNode currentNode = null;

            while (true)
            {
                while (true)
                {
                    if (bufferPos == -1)
                    {
                        currentByte = data.ReadByte();
                        bufferPos = 7;
                    }

                    int bitmask = 1 << (bufferPos);
                    int currentBit = ((currentByte & bitmask) >> (bufferPos));
                    currentByte = currentByte & 255 - bitmask;

                    bufferPos--;

                    if (currentNode == null)
                        currentNode = rootNode;
                    else if (currentBit == 0)
                        currentNode = currentNode.LeftNode;
                    else
                        currentNode = currentNode.RightNode;

                    if (currentNode.IsLeaf)
                    {
                        break;
                    }
                }
                result.WriteByte(currentNode.Data);
                currentNode = null;

                if (endBufferPos == 7)
                    endBufferPos = -1;

                if (data.Position == data.Length - 1 && bufferPos == endBufferPos)
                    break;
            }

            byte[] compressedBytes = new byte[result.Length];
            result.Position = 0;
            result.Read(compressedBytes, 0, compressedBytes.Length);
            return compressedBytes;
        }
    }
}