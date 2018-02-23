using System.Reflection;

namespace Cerseil.ObjectMapping
{
    public class PropertyMatch
    {
        public PropertyMatch(PropertyInfo sourceProp, PropertyInfo destinationProp)
        {
            SourceProperty = sourceProp;
            DestinationProperty = destinationProp;
        }

        public PropertyInfo SourceProperty { get; private set; }

        public PropertyInfo DestinationProperty { get; private set; }
    }
}
