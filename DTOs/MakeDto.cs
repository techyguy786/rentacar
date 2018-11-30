using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.DTOs
{
    public class MakeDto
    {
        public int MakeId { get; set; }
        public string Name { get; set; }
        public ICollection<ModelDto> Models { get; set; }
        public MakeDto()
        {
            Models = new Collection<ModelDto>();
        }
    }
}