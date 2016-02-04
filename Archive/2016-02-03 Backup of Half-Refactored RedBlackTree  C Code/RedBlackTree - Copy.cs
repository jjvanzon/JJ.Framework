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

//#ifndef _RBTREE_H_

//internal enum NodeColorEnum
//{
//    Red,
//    Black
//}

//internal class Node
//{
//    void* key;
//    void* value;
//    Node left;
//    Node right;
//    Node parent;
//    enum NodeColorEnum NodeColorEnum;
//}

//internal class RedBlackTree
//{
//    Node root;
//}

////typedef int (* compare_func)(void* left, void* right);

//internal delegate int (* compare_func_delegate)(void* left, void* right);

//internal interface IRedBlackTree
//{
//    RedBlackTree rbtree_create();
//    void* rbtree_lookup(RedBlackTree t, void* key, compare_func_delegate compare);
//    void rbtree_insert(RedBlackTree t, void* key, void* value, compare_func_delegate compare);
//    void rbtree_delete(RedBlackTree t, void* key, compare_func_delegate compare);
//}

//#endif

//static Node grandparent(Node n);
//static Node sibling(Node n);
//static Node uncle(Node n);
//static void verify_properties(RedBlackTree t);
//static void verify_property_1(Node root);
//static void verify_property_2(Node root);
//static NodeColorEnum node_color(Node n);
//static void verify_property_4(Node root);
//static void verify_property_5(Node root);
//static void verify_property_5_helper(Node n, int black_count, int* black_count_path);

//static Node new_node(void* key, void* value, NodeColorEnum node_color, Node left, Node right);
//static Node lookup_node(RedBlackTree t, void* key, compare_func_delegate compare);
//static void rotate_left(RedBlackTree t, Node n);
//static void rotate_right(RedBlackTree t, Node n);

//static void replace_node(RedBlackTree t, Node oldn, Node newn);
//static void insert_case1(RedBlackTree t, Node n);
//static void insert_case2(RedBlackTree t, Node n);
//static void insert_case3(RedBlackTree t, Node n);
//static void insert_case4(RedBlackTree t, Node n);
//static void insert_case5(RedBlackTree t, Node n);
//static Node maximum_node(Node root);
//static void delete_case1(RedBlackTree t, Node n);
//static void delete_case2(RedBlackTree t, Node n);
//static void delete_case3(RedBlackTree t, Node n);
//static void delete_case4(RedBlackTree t, Node n);
//static void delete_case5(RedBlackTree t, Node n);
//static void delete_case6(RedBlackTree t, Node n);

//Node grandparent(Node n)
//{
//    assert(n != null);
//    assert(n.parent != null); /* Not the root Node */
//    assert(n.parent.parent != null); /* Not child of root */
//    return n.parent.parent;
//}

//Node sibling(Node n)
//{
//    assert(n != null);
//    assert(n.parent != null); /* Root Node has no sibling */
//    if (n == n.parent.left)
//        return n.parent.right;
//    else
//        return n.parent.left;
//}

//Node uncle(Node n)
//{
//    assert(n != null);
//    assert(n.parent != null); /* Root Node has no uncle */
//    assert(n.parent.parent != null); /* Children of root have no uncle */
//    return sibling(n.parent);
//}

//void verify_properties(RedBlackTree t)
//{
//#ifdef VERIFY_RBTREE
//    verify_property_1(t.root);
//    verify_property_2(t.root);
//    /* Property 3 is implicit */
//    verify_property_4(t.root);
//    verify_property_5(t.root);
//#endif
//}

//void verify_property_1(Node n)
//{
//    assert(node_color(n) == NodeColorEnum.Red || node_color(n) == NodeColorEnum.Black);
//    if (n == null) return;
//    verify_property_1(n.left);
//    verify_property_1(n.right);
//}

//void verify_property_2(Node root)
//{
//    assert(node_color(root) == NodeColorEnum.Black);
//}

//NodeColorEnum node_color(Node n)
//{
//    return n == null ? NodeColorEnum.Black : n.NodeColorEnum;
//}

//void verify_property_4(Node n)
//{
//    if (node_color(n) == NodeColorEnum.Red)
//    {
//        assert(node_color(n.left) == NodeColorEnum.Black);
//        assert(node_color(n.right) == NodeColorEnum.Black);
//        assert(node_color(n.parent) == NodeColorEnum.Black);
//    }
//    if (n == null) return;
//    verify_property_4(n.left);
//    verify_property_4(n.right);
//}

//void verify_property_5(Node root)
//{
//    int black_count_path = -1;
//    verify_property_5_helper(root, 0, &black_count_path);
//}

//void verify_property_5_helper(Node n, int black_count, int* path_black_count)
//{
//    if (node_color(n) == NodeColorEnum.Black)
//    {
//        black_count++;
//    }
//    if (n == null)
//    {
//        if (*path_black_count == -1)
//        {
//            *path_black_count = black_count;
//        }
//        else {
//            assert(black_count == *path_black_count);
//        }
//        return;
//    }
//    verify_property_5_helper(n.left, black_count, path_black_count);
//    verify_property_5_helper(n.right, black_count, path_black_count);
//}

//public RedBlackTree rbtree_create()
//{
//    RedBlackTree t = malloc(sizeof(struct RedBlackTree));
//    t.root = null;
//    verify_properties(t);
//    return t;
//}

//Node new_node(void* key, void* value, NodeColorEnum node_color, Node left, Node right)
//{
//    Node result = malloc(sizeof(struct Node));
//    result.key = key;
//    result.value = value;
//    result.NodeColorEnum = node_color;
//    result.left = left;
//    result.right = right;
//    if (left  != null)  left.parent = result;
//    if (right != null) right.parent = result;
//    result.parent = null;
//    return result;
//}

//Node lookup_node(RedBlackTree t, void* key, compare_func_delegate compare)
//{
//    Node n = t.root;
//    while (n != null)
//    {
//        int comp_result = compare(key, n.key);
//        if (comp_result == 0)
//        {
//            return n;
//        }
//        else if (comp_result < 0)
//        {
//            n = n.left;
//        }
//        else {
//            assert(comp_result > 0);
//            n = n.right;
//        }
//    }
//    return n;
//}

//public void* rbtree_lookup(RedBlackTree t, void* key, compare_func_delegate compare)
//{
//    Node n = lookup_node(t, key, compare);
//    return n == null ? null : n.value;
//}

//void rotate_left(RedBlackTree t, Node n)
//{
//    Node r = n.right;
//    replace_node(t, n, r);
//    n.right = r.left;
//    if (r.left != null)
//    {
//        r.left.parent = n;
//    }
//    r.left = n;
//    n.parent = r;
//}

//void rotate_right(RedBlackTree t, Node n)
//{
//    Node L = n.left;
//    replace_node(t, n, L);
//    n.left = L.right;
//    if (L.right != null)
//    {
//        L.right.parent = n;
//    }
//    L.right = n;
//    n.parent = L;
//}

//void replace_node(RedBlackTree t, Node oldn, Node newn)
//{
//    if (oldn.parent == null)
//    {
//        t.root = newn;
//    }
//    else {
//        if (oldn == oldn.parent.left)
//            oldn.parent.left = newn;
//        else
//            oldn.parent.right = newn;
//    }
//    if (newn != null)
//    {
//        newn.parent = oldn.parent;
//    }
//}

//public void rbtree_insert(RedBlackTree t, void* key, void* value, compare_func_delegate compare)
//{
//    Node inserted_node = new_node(key, value, NodeColorEnum.Red, null, null);
//    if (t.root == null)
//    {
//        t.root = inserted_node;
//    }
//    else {
//        Node n = t.root;
//        while (1)
//        {
//            int comp_result = compare(key, n.key);
//            if (comp_result == 0)
//            {
//                n.value = value;
//                return;
//            }
//            else if (comp_result < 0)
//            {
//                if (n.left == null)
//                {
//                    n.left = inserted_node;
//                    break;
//                }
//                else {
//                    n = n.left;
//                }
//            }
//            else {
//                assert(comp_result > 0);
//                if (n.right == null)
//                {
//                    n.right = inserted_node;
//                    break;
//                }
//                else {
//                    n = n.right;
//                }
//            }
//        }
//        inserted_node.parent = n;
//    }
//    insert_case1(t, inserted_node);
//    verify_properties(t);
//}

//void insert_case1(RedBlackTree t, Node n)
//{
//    if (n.parent == null)
//        n.NodeColorEnum = NodeColorEnum.Black;
//    else
//        insert_case2(t, n);
//}

//void insert_case2(RedBlackTree t, Node n)
//{
//    if (node_color(n.parent) == NodeColorEnum.Black)
//        return; /* Tree is still valid */
//    else
//        insert_case3(t, n);
//}

//void insert_case3(RedBlackTree t, Node n)
//{
//    if (node_color(uncle(n)) == NodeColorEnum.Red)
//    {
//        n.parent.NodeColorEnum = NodeColorEnum.Black;
//        uncle(n).NodeColorEnum = NodeColorEnum.Black;
//        grandparent(n).NodeColorEnum = NodeColorEnum.Red;
//        insert_case1(t, grandparent(n));
//    }
//    else {
//        insert_case4(t, n);
//    }
//}

//void insert_case4(RedBlackTree t, Node n)
//{
//    if (n == n.parent.right && n.parent == grandparent(n).left)
//    {
//        rotate_left(t, n.parent);
//        n = n.left;
//    }
//    else if (n == n.parent.left && n.parent == grandparent(n).right)
//    {
//        rotate_right(t, n.parent);
//        n = n.right;
//    }
//    insert_case5(t, n);
//}

//void insert_case5(RedBlackTree t, Node n)
//{
//    n.parent.NodeColorEnum = NodeColorEnum.Black;
//    grandparent(n).NodeColorEnum = NodeColorEnum.Red;
//    if (n == n.parent.left && n.parent == grandparent(n).left)
//    {
//        rotate_right(t, grandparent(n));
//    }
//    else {
//        assert(n == n.parent.right && n.parent == grandparent(n).right);
//        rotate_left(t, grandparent(n));
//    }
//}

//public void rbtree_delete(RedBlackTree t, void* key, compare_func_delegate compare)
//{
//    Node child;
//    Node n = lookup_node(t, key, compare);
//    if (n == null) return;  /* Key not found, do nothing */
//    if (n.left != null && n.right != null)
//    {
//        /* Copy key/value from predecessor and then delete it instead */
//        Node pred = maximum_node(n.left);
//        n.key = pred.key;
//        n.value = pred.value;
//        n = pred;
//    }

//    assert(n.left == null || n.right == null);
//    child = n.right == null ? n.left : n.right;
//    if (node_color(n) == NodeColorEnum.Black)
//    {
//        n.NodeColorEnum = node_color(child);
//        delete_case1(t, n);
//    }
//    replace_node(t, n, child);
//    if (n.parent == null && child != null) // root should be black
//        child.NodeColorEnum = NodeColorEnum.Black;
//    free(n);

//    verify_properties(t);
//}

//static Node maximum_node(Node n)
//{
//    assert(n != null);
//    while (n.right != null)
//    {
//        n = n.right;
//    }
//    return n;
//}

//void delete_case1(RedBlackTree t, Node n)
//{
//    if (n.parent == null)
//        return;
//    else
//        delete_case2(t, n);
//}

//void delete_case2(RedBlackTree t, Node n)
//{
//    if (node_color(sibling(n)) == NodeColorEnum.Red)
//    {
//        n.parent.NodeColorEnum = NodeColorEnum.Red;
//        sibling(n).NodeColorEnum = NodeColorEnum.Black;
//        if (n == n.parent.left)
//            rotate_left(t, n.parent);
//        else
//            rotate_right(t, n.parent);
//    }
//    delete_case3(t, n);
//}

//void delete_case3(RedBlackTree t, Node n)
//{
//    if (node_color(n.parent) == NodeColorEnum.Black &&
//        node_color(sibling(n)) == NodeColorEnum.Black &&
//        node_color(sibling(n).left) == NodeColorEnum.Black &&
//        node_color(sibling(n).right) == NodeColorEnum.Black)
//    {
//        sibling(n).NodeColorEnum = NodeColorEnum.Red;
//        delete_case1(t, n.parent);
//    }
//    else
//        delete_case4(t, n);
//}

//void delete_case4(RedBlackTree t, Node n)
//{
//    if (node_color(n.parent) == NodeColorEnum.Red &&
//        node_color(sibling(n)) == NodeColorEnum.Black &&
//        node_color(sibling(n).left) == NodeColorEnum.Black &&
//        node_color(sibling(n).right) == NodeColorEnum.Black)
//    {
//        sibling(n).NodeColorEnum = NodeColorEnum.Red;
//        n.parent.NodeColorEnum = NodeColorEnum.Black;
//    }
//    else
//        delete_case5(t, n);
//}

//void delete_case5(RedBlackTree t, Node n)
//{
//    if (n == n.parent.left &&
//        node_color(sibling(n)) == NodeColorEnum.Black &&
//        node_color(sibling(n).left) == NodeColorEnum.Red &&
//        node_color(sibling(n).right) == NodeColorEnum.Black)
//    {
//        sibling(n).NodeColorEnum = NodeColorEnum.Red;
//        sibling(n).left.NodeColorEnum = NodeColorEnum.Black;
//        rotate_right(t, sibling(n));
//    }
//    else if (n == n.parent.right &&
//             node_color(sibling(n)) == NodeColorEnum.Black &&
//             node_color(sibling(n).right) == NodeColorEnum.Red &&
//             node_color(sibling(n).left) == NodeColorEnum.Black)
//    {
//        sibling(n).NodeColorEnum = NodeColorEnum.Red;
//        sibling(n).right.NodeColorEnum = NodeColorEnum.Black;
//        rotate_left(t, sibling(n));
//    }
//    delete_case6(t, n);
//}

//void delete_case6(RedBlackTree t, Node n)
//{
//    sibling(n).NodeColorEnum = node_color(n.parent);
//    n.parent.NodeColorEnum = NodeColorEnum.Black;
//    if (n == n.parent.left)
//    {
//        assert(node_color(sibling(n).right) == NodeColorEnum.Red);
//        sibling(n).right.NodeColorEnum = NodeColorEnum.Black;
//        rotate_left(t, n.parent);
//    }
//    else
//    {
//        assert(node_color(sibling(n).left) == NodeColorEnum.Red);
//        sibling(n).left.NodeColorEnum = NodeColorEnum.Black;
//        rotate_right(t, n.parent);
//    }
//}
