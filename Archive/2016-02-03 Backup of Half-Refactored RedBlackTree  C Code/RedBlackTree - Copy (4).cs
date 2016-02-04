///* The authors of this work have released all rights to it and placed it
//in the public domain under the Creative Commons CC0 1.0 waiver
//(http://creativecommons.org/publicdomain/zero/1.0/).

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

//Retrieved from: http://en.literateprograms.org/Red-black_tree_(C)?oldid=19567
//*/

//using System;
//using JJ.Framework.Reflection.Exceptions;

//namespace JJ.Business.Synthesizer.BasicDataStructures
//{
//    internal enum RedBlackTreeColorEnum
//    {
//        Red,
//        Black
//    }

//    internal delegate int compare_func_delegate(void* left, void* right);

//    internal interface IRedBlackTree
//    {
//        void* rbtree_lookup(void* key, compare_func_delegate compare);
//        void rbtree_insert(void* key, void* value, compare_func_delegate compare);
//        void rbtree_delete(void* key, compare_func_delegate compare);
//    }

//    internal static class RedBlackTreeHelper
//    {
//        public static void Assert(bool condition)
//        {
//            if (!condition) throw new Exception("Assertion failed.");
//        }
//    }

//    internal class RedBlackTree
//    {
//        private RedBlackTreeNode root;

//        public RedBlackTree()
//        {
//            root = null;
//        }

//        public void* rbtree_lookup(void* key, compare_func_delegate compare)
//        {
//            RedBlackTreeNode node = lookup_node(key, compare);
//            return node == null ? null : node.value;
//        }

//        private RedBlackTreeNode lookup_node(void* key, compare_func_delegate compare)
//        {
//            RedBlackTreeNode node = root;
//            while (node != null)
//            {
//                int comp_result = compare(key, node.key);
//                if (comp_result == 0)
//                {
//                    return node;
//                }
//                else if (comp_result < 0)
//                {
//                    node = node.left;
//                }
//                else {
//                    RedBlackTreeHelper.Assert(comp_result > 0);
//                    node = node.right;
//                }
//            }
//            return node;
//        }

//        private void rotate_left(RedBlackTreeNode node)
//        {
//            RedBlackTreeNode r = node.right;
//            replace_node( node, r);
//            node.right = r.left;
//            if (r.left != null)
//            {
//                r.left.parent = node;
//            }
//            r.left = node;
//            node.parent = r;
//        }

//        private void rotate_right(RedBlackTreeNode node)
//        {
//            RedBlackTreeNode L = node.left;
//            replace_node(node, L);
//            node.left = L.right;
//            if (L.right != null)
//            {
//                L.right.parent = node;
//            }
//            L.right = node;
//            node.parent = L;
//        }

//        private void replace_node(RedBlackTreeNode oldn, RedBlackTreeNode newn)
//        {
//            if (oldn.parent == null)
//            {
//                root = newn;
//            }
//            else {
//                if (oldn == oldn.parent.left)
//                    oldn.parent.left = newn;
//                else
//                    oldn.parent.right = newn;
//            }
//            if (newn != null)
//            {
//                newn.parent = oldn.parent;
//            }
//        }

//        public void rbtree_insert(void* key, void* value, compare_func_delegate compare)
//        {
//            RedBlackTreeNode inserted_node = new_node(key, value, RedBlackTreeColorEnum.Red, null, null);
//            if (root == null)
//            {
//                root = inserted_node;
//            }
//            else {
//                RedBlackTreeNode node = root;
//                while (1)
//                {
//                    int comp_result = compare(key, node.key);
//                    if (comp_result == 0)
//                    {
//                        node.value = value;
//                        return;
//                    }
//                    else if (comp_result < 0)
//                    {
//                        if (node.left == null)
//                        {
//                            node.left = inserted_node;
//                            break;
//                        }
//                        else {
//                            node = node.left;
//                        }
//                    }
//                    else {
//                        RedBlackTreeHelper.Assert(comp_result > 0);
//                        if (node.right == null)
//                        {
//                            node.right = inserted_node;
//                            break;
//                        }
//                        else {
//                            node = node.right;
//                        }
//                    }
//                }
//                inserted_node.parent = node;
//            }
//            insert_case1(inserted_node);
//        }

//        private void insert_case1(RedBlackTreeNode node)
//        {
//            if (node.parent == null)
//                node.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//            else
//                insert_case2(node);
//        }

//        private void insert_case2(RedBlackTreeNode node)
//        {
//            if (node_color(node.parent) == RedBlackTreeColorEnum.Black)
//                return; /* Tree is still valid */
//            else
//                insert_case3(node);
//        }

//        private void insert_case3(RedBlackTreeNode node)
//        {
//            if (node_color(node.uncle()) == RedBlackTreeColorEnum.Red)
//            {
//                node.parent.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                node.uncle().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                node.grandparent().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//                insert_case1(node.grandparent());
//            }
//            else {
//                insert_case4(node);
//            }
//        }

//        private void insert_case4(RedBlackTreeNode node)
//        {
//            if (node == node.parent.right && node.parent == node.grandparent().left)
//            {
//                rotate_left(node.parent);
//                node = node.left;
//            }
//            else if (node == node.parent.left && node.parent == node.grandparent().right)
//            {
//                rotate_right(node.parent);
//                node = node.right;
//            }

//            insert_case5(node);
//        }

//        private void insert_case5(RedBlackTreeNode node)
//        {
//            node.parent.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//            node.grandparent().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//            if (node == node.parent.left && node.parent == node.grandparent().left)
//            {
//                rotate_right(node.grandparent());
//            }
//            else {
//                RedBlackTreeHelper.Assert(node == node.parent.right && node.parent == node.grandparent().right);
//                rotate_left(node.grandparent());
//            }
//        }

//        public void rbtree_delete(void* key, compare_func_delegate compare)
//        {
//            RedBlackTreeNode child;
//            RedBlackTreeNode node = lookup_node(key, compare);
//            if (node == null) return;  /* Key not found, do nothing */
//            if (node.left != null && node.right != null)
//            {
//                /* Copy key/value from predecessor and then delete it instead */
//                RedBlackTreeNode pred = maximum_node(node.left);
//                node.key = pred.key;
//                node.value = pred.value;
//                node = pred;
//            }

//            RedBlackTreeHelper.Assert(node.left == null || node.right == null);
//            child = node.right == null ? node.left : node.right;
//            if (node_color(node) == RedBlackTreeColorEnum.Black)
//            {
//                node.RedBlackTreeColorEnum = node_color(child);
//                delete_case1(node);
//            }
//            replace_node(node, child);
//            if (node.parent == null && child != null) // root should be black
//                child.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//            free(node);

//        }

//        private void delete_case1(RedBlackTreeNode node)
//        {
//            if (node.parent == null)
//                return;
//            else
//                delete_case2(node);
//        }

//        private void delete_case2(RedBlackTreeNode node)
//        {
//            if (node_color(node.sibling()) == RedBlackTreeColorEnum.Red)
//            {
//                node.parent.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//                node.sibling().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                if (node == node.parent.left)
//                    rotate_left(node.parent);
//                else
//                    rotate_right(node.parent);
//            }
//            delete_case3(node);
//        }

//        private void delete_case3(RedBlackTreeNode node)
//        {
//            if (node_color(node.parent) == RedBlackTreeColorEnum.Black &&
//                node_color(node.sibling()) == RedBlackTreeColorEnum.Black &&
//                node_color(node.sibling().left) == RedBlackTreeColorEnum.Black &&
//                node_color(node.sibling().right) == RedBlackTreeColorEnum.Black)
//            {
//                node.sibling().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//                delete_case1(node.parent);
//            }
//            else
//                delete_case4(node);
//        }

//        private void delete_case4(RedBlackTreeNode node)
//        {
//            if (node_color(node.parent) == RedBlackTreeColorEnum.Red &&
//                node_color(node.sibling()) == RedBlackTreeColorEnum.Black &&
//                node_color(node.sibling().left) == RedBlackTreeColorEnum.Black &&
//                node_color(node.sibling().right) == RedBlackTreeColorEnum.Black)
//            {
//                node.sibling().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//                node.parent.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//            }
//            else
//                delete_case5(node);
//        }

//        private void delete_case5(RedBlackTreeNode node)
//        {
//            if (node == node.parent.left &&
//                node_color(node.sibling()) == RedBlackTreeColorEnum.Black &&
//                node_color(node.sibling().left) == RedBlackTreeColorEnum.Red &&
//                node_color(node.sibling().right) == RedBlackTreeColorEnum.Black)
//            {
//                node.sibling().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//                node.sibling().left.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                rotate_right(node.sibling());
//            }
//            else if (node == node.parent.right &&
//                     node_color(node.sibling()) == RedBlackTreeColorEnum.Black &&
//                     node_color(node.sibling().right) == RedBlackTreeColorEnum.Red &&
//                     node_color(node.sibling().left) == RedBlackTreeColorEnum.Black)
//            {
//                node.sibling().RedBlackTreeColorEnum = RedBlackTreeColorEnum.Red;
//                node.sibling().right.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                rotate_left(node.sibling());
//            }
//            delete_case6(node);
//        }

//        private void delete_case6(RedBlackTreeNode node)
//        {
//            node.sibling().RedBlackTreeColorEnum = node_color(node.parent);
//            node.parent.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//            if (node == node.parent.left)
//            {
//                RedBlackTreeHelper.Assert(node_color(node.sibling().right) == RedBlackTreeColorEnum.Red);
//                node.sibling().right.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                rotate_left(node.parent);
//            }
//            else
//            {
//                RedBlackTreeHelper.Assert(node_color(node.sibling().left) == RedBlackTreeColorEnum.Red);
//                node.sibling().left.RedBlackTreeColorEnum = RedBlackTreeColorEnum.Black;
//                rotate_right(node.parent);
//            }
//        }
//    }

//    internal class RedBlackTreeNode
//    {
//        void* key;
//        void* value;
//        public RedBlackTreeNode left;
//        public RedBlackTreeNode right;
//        public RedBlackTreeNode parent;
//        public RedBlackTreeColorEnum RedBlackTreeColorEnum;

//        public RedBlackTreeNode(
//            void* key, 
//            void* value, 
//            RedBlackTreeColorEnum node_color, 
//            RedBlackTreeNode left, 
//            RedBlackTreeNode right)
//        {
//            this.key = key;
//            this.value = value;
//            this.RedBlackTreeColorEnum = node_color;
//            this.left = left;
//            this.right = right;
//            if (left != null) left.parent = this;
//            if (right != null) right.parent = this;
//            this.parent = null;
//        }

//        public RedBlackTreeNode grandparent()
//        {
//            RedBlackTreeHelper.Assert(parent != null); /* Not the root RedBlackTreeNode */
//            RedBlackTreeHelper.Assert(parent.parent != null); /* Not child of root */
//            return parent.parent;
//        }

//        public RedBlackTreeNode sibling()
//        {
//            RedBlackTreeHelper.Assert(parent != null); /* Root RedBlackTreeNode has no sibling */
//            if (this == parent.left)
//            {
//                return parent.right;
//            }
//            else
//            {
//                return parent.left;
//            }
//        }

//        public RedBlackTreeNode uncle()
//        {
//            RedBlackTreeHelper.Assert(parent != null); /* Root RedBlackTreeNode has no uncle */
//            RedBlackTreeHelper.Assert(parent.parent != null); /* Children of root have no uncle */
//            return sibling(parent);
//        }

//        public RedBlackTreeColorEnum node_color()
//        {
//            // TODO: When can node ever by null?
//            return node == null ? RedBlackTreeColorEnum.Black : node.RedBlackTreeColorEnum;
//        }

//        static RedBlackTreeNode maximum_node(RedBlackTreeNode node)
//        {
//            RedBlackTreeHelper.Assert(node != null);
//            while (node.right != null)
//            {
//                node = node.right;
//            }
//            return node;
//        }
//    }

//}