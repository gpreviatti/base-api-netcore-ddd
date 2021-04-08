using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CrossCutting.Mappings;
using Tests.AutoMapper;

namespace Tests.Service
{
    public abstract class BaseServiceTest
    {
        protected readonly IMapper _mapper;

        public BaseServiceTest()
        {
            _mapper = new BaseMapperTest().GetMapper();
        }
    }
}
