using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.DTOs
{
    public class MakeDto : KeyValuePairDto
    {
        public ICollection<KeyValuePairDto> Models { get; set; }
        public MakeDto()
        {
            Models = new Collection<KeyValuePairDto>();
        }
    }
}