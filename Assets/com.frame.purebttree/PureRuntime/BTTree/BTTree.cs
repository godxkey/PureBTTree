using System.Collections.Generic;

namespace JackFrame.BTTreeNS {

    public class BTTree {

        BTTreeNode root;
        public BTTreeNode Root => root;

        public BTTree() { }

        public void Initialize(BTTreeNode root) {
            this.root = root;
            root.Activate();
        }

        public void Activate() {
            this.root.Activate();
        }

        public void Tick() {

            if (root == null) {
                throw new System.Exception("未 Initalize");
            }

            if (!root.IsActivated) {
                return;
            }

            bool res = root.Evaluate();
            if (res) {
                root.Tick();
            }

        }

        public List<BTTreeNode> GetCurrentActionNodes(BTTreeNode node, List<BTTreeNode> res) {
            var children = node.GetChildren;
            res.AddRange(children.FindAll(value => value.NodeType == BTTreeNodeType.Action && value.NodeStatus == BTTreeNodeStatus.Execute));
            children.ForEach(child => GetCurrentActionNodes(child, res));
            return res;
        }

    }

}