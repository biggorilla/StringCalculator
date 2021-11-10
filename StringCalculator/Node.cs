using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StringCalculator
{
	public class Node : EqualityComparer<Node>
	{
		private Guid UniqueIdentifier;
		public Node()
		{
			UniqueIdentifier = Guid.NewGuid();
		}

		private Object Data;

		public Node Previous;
		public Node Next;

		public override string ToString()
		{
			return UniqueIdentifier.ToString();
		}


		public override bool Equals([AllowNull] Node x, [AllowNull] Node y)
		{
			return x.UniqueIdentifier.Equals(y.UniqueIdentifier);
		}

		public override int GetHashCode([DisallowNull] Node obj)
		{
			return obj.UniqueIdentifier.GetHashCode();
		}
	}
}
