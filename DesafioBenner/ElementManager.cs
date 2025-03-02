namespace DesafioBenner
{
    public class ElementManager
    {
        Element[] _elements { get; set; }

        public ElementManager(int numberOfElements)
        {
            if (numberOfElements <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfElements));
            }

            _elements = [.. Enumerable.Range(1, numberOfElements).Select(n => new Element(n))];
        }

        public void Connect(int firstElement, int secondElement)
        {
            if (firstElement <= 0 || _elements.Length < firstElement)
            {
                throw new ArgumentOutOfRangeException(nameof(firstElement));
            }

            if (secondElement <= 0 || _elements.Length < secondElement)
            {
                throw new ArgumentOutOfRangeException(nameof(secondElement));
            }

            Element? first = _elements.FirstOrDefault(x => x.Number == firstElement);
            if (first == null)
            {
                throw new InvalidOperationException("Can't find the element.");
            }

            Element? second = _elements.FirstOrDefault(x => x.Number == secondElement);
            if (second == null)
            {
                throw new InvalidOperationException("Can't find the element.");
            }

            first.Connections.Add(second.Number);
            second.Connections.Add(first.Number);
        }

        public void Disconnect(int firstElement, int secondElement)
        {
            if (firstElement <= 0 || _elements.Length < firstElement)
            {
                throw new ArgumentOutOfRangeException(nameof(firstElement));
            }

            if (secondElement <= 0 || _elements.Length < secondElement)
            {
                throw new ArgumentOutOfRangeException(nameof(secondElement));
            }

            Element? first = _elements.FirstOrDefault(x => x.Number == firstElement);
            if (first == null)
            {
                throw new InvalidOperationException("Can't find the element.");
            }

            Element? second = _elements.FirstOrDefault(x => x.Number == secondElement);
            if (second == null)
            {
                throw new InvalidOperationException("Can't find the element.");
            }

            first.Connections.Remove(second.Number);
            second.Connections.Remove(first.Number);
        }

        public bool Query(int firstElement, int secondElement)
        {
            if (firstElement <= 0 || _elements.Length < firstElement)
            {
                throw new ArgumentOutOfRangeException(nameof(firstElement));
            }

            if (secondElement <= 0 || _elements.Length < secondElement)
            {
                throw new ArgumentOutOfRangeException(nameof(secondElement));
            }

            Element? first = _elements.FirstOrDefault(x => x.Number == firstElement);
            if (first == null)
            {
                throw new InvalidOperationException("Can't find the element.");
            }

            HashSet<int> searchedElements = [secondElement];

            int connectionLevel = 0;

            return QueryInternal(first.Connections, searchedElements, secondElement, ref connectionLevel);
        }

        private bool QueryInternal(HashSet<int> connections, HashSet<int> searchedElements, int elementToFind, ref int connectionLevel)
        {
            if (connections == null)
            {
                throw new ArgumentNullException(nameof(connections));
            }

            if (searchedElements == null)
            {
                throw new ArgumentNullException(nameof(searchedElements));
            }

            if (elementToFind <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(searchedElements));
            }

            connectionLevel += 1;

            if (connections.Count <= 0)
            {
                return false;
            }

            if (connections.Contains(elementToFind))
            {
                return true;
            }

            bool finded = false;
            Element? element;
            foreach (int item in connections)
            {
                if (item <= 0)
                {
                    continue;
                }

                if (searchedElements.Contains(item))
                {
                    continue;
                }

                element = _elements.FirstOrDefault(x => x.Number == item);
                if (element == null)
                {
                    continue;
                }

                searchedElements.Add(element.Number);

                finded = QueryInternal(element.Connections, searchedElements, elementToFind, ref connectionLevel);
                if (finded)
                {
                    break;
                }

                connectionLevel -= 1;
            }

            return finded;
        }

        public int LevelConnetion(int firstElement, int secondElement)
        {
            if (firstElement <= 0 || _elements.Length < firstElement)
            {
                throw new ArgumentOutOfRangeException(nameof(firstElement));
            }

            if (secondElement <= 0 || _elements.Length < secondElement)
            {
                throw new ArgumentOutOfRangeException(nameof(secondElement));
            }

            Element? first = _elements.FirstOrDefault(x => x.Number == firstElement);
            if (first == null)
            {
                throw new InvalidOperationException("Can't find the element.");
            }

            HashSet<int> searchedElements = [secondElement];

            int connectionLevel = 0;

            bool connected = QueryInternal(first.Connections, searchedElements, secondElement, ref connectionLevel);

            return connected ? connectionLevel : 0;
        }
    }
}
