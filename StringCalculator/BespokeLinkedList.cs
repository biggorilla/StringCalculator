using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
	public class BespokeLinkedList
	{
		public BespokeLinkedList(Node node)
		{
			Insert(node);
		}

		private Node HeadNode;

		public BespokeLinkedList Insert(Node node)
		{
			if  (HeadNode != null) node.Previous = HeadNode;
			if (HeadNode.Previous != null) HeadNode.Previous.Next = node;
			HeadNode = node;
			return this;
		}

		public BespokeLinkedList InsertAt(int listPosition, Node node)
		{
			var nodePointer = HeadNode;
			var nodeList = new List<Node>();
			
			do
			{
				nodeList.Add(node);
				nodePointer = nodePointer.Previous;
			} while (nodePointer != null);

			nodeList.Reverse();

			if (listPosition > nodeList.Count() || (listPosition-1) <0 )
			{
				throw new Exception("list position out of range");
			}
			var nodeTakingAddition = nodeList[listPosition - 1];

			var nextHook = nodeTakingAddition.Next;

			node.Next = nextHook;
			node.Previous = nodeTakingAddition;

			return this;
		}

		public BespokeLinkedList Delete(Node node)
		{
			var nodePointer = HeadNode;
			if (nodePointer == node)
			{
				HeadNode.Previous.Next = null;
			}
			else
			{
				do { 
					nodePointer = nodePointer.Previous;
					if (nodePointer == node)
					{ nodePointer.Previous.Next = nodePointer.Next; }
				} while (nodePointer != null);
			}
			return this;
		}

		public string PrintList()
		{
			var listDescription = new StringBuilder();
			var nodePointer = HeadNode.Previous;

			do
			{
				listDescription.Append(HeadNode.ToString());
				
				if (nodePointer != null) listDescription.Append(nodePointer.ToString()) ;

				nodePointer = nodePointer.Previous;
			
			} while (nodePointer != null);

			return listDescription.ToString();
		}

	}
}
