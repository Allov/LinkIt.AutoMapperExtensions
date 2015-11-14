using System;
using AutoMapper;
using NUnit.Framework;

namespace LinkIt.AutoMapperExtensions.Tests
{
    [TestFixture]
    public class AutoMapReference_PreconditionsTests 
    {
        [TearDown]
        public void TearDown()
        {
            Mapper.Reset();
        }

        [Test]
        public void MapModel_WithoutModelProperty_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(()=>            
                Mapper
                .CreateMap<WannaBeLinkedSource, string>()
                .MapLinkedSource()
            );
        }

        [Test]
        public void MapModel_WithPrimitiveModel_ShouldThrowArgumentException() {
            Assert.Throws<ArgumentException>(() =>
                Mapper
                .CreateMap<PrimitiveLinkedSource, string>()
                .MapLinkedSource()
            );
        }


        public class WannaBeLinkedSource
        {
            public Tuple<string, string> NotAModel { get; set; }
        }

        public class PrimitiveLinkedSource {
            public int Model { get; set; }
        }
    }
}