#region License

// SLNTools
// Copyright (c) 2009
// by Christian Warren
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

#endregion

using System;

namespace CWDev.SLNTools.Core.Merge
{
    public abstract class Difference
    {
        private readonly ElementIdentifier r_identifier;
        private readonly OperationOnParent r_operationOnParent;

        protected Difference(
                    ElementIdentifier identifier,
                    OperationOnParent operationOnParent)
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");
            if (! Enum.IsDefined(operationOnParent.GetType(), operationOnParent))
                throw new ArgumentOutOfRangeException("operationOnParent", operationOnParent, "Invalid value");
            r_identifier = identifier;
            r_operationOnParent = operationOnParent;
        }

        public ElementIdentifier Identifier { get { return r_identifier; } }
        public OperationOnParent OperationOnParent { get { return r_operationOnParent; } }

        public abstract Conflict CompareTo(Difference destinationDifference);
    }
}
