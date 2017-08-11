using System;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using Rico.S07.AutoMapperV3.Common;
using Rico.S07.AutoMapperV3.Dto;
using Rico.S07.AutoMapperV3.Model;

namespace Rico.S07.AutoMapperV3
{
    /// <summary>
    /// Automapper 3.3.1 Demo
    /// source:http://www.cnblogs.com/ljzforever/archive/2011/12/29/2305500.html
    /// </summary>
    class SimpleMain
    {
        #region 基础API
        /// <summary>
        /// 普通转换
        /// </summary>
        public static void NormalConvert()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };

            Mapper.CreateMap<Name, NameDto>()
            .BeforeMap((name, nameDto)
                        => Console.WriteLine("Before：\t" + nameDto.FirstName + "\t" + nameDto.LastName))
            .AfterMap((name, nameDto)
                       => Console.WriteLine("After：\t" + nameDto.FirstName + "\t" + nameDto.LastName));

            NameDto nameDto1 = Mapper.Map<Name, NameDto>(nameModel);

            Console.WriteLine(nameDto1.FirstName + nameDto1.LastName);
        }

        /// <summary>
        /// 整体即时转换
        /// </summary>
        public static void AllConvertImmediately()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };

            Mapper.CreateMap<Name, NameDto>()
            .ConstructUsing(name => new NameDto() { AllName = name.FirstName + name.LastName });

            NameDto nameDto = Mapper.Map<Name, NameDto>(nameModel);

            Console.WriteLine(nameDto.AllName);
        }
        /// <summary>
        /// 3.整体通过TypeConverter类型转换
        /// </summary>
        public static void TypeConvert()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };
            Mapper.CreateMap<Name, NameDto>()
            .ConvertUsing<NameConverter>();

            NameDto nameDto3 = Mapper.Map<Name, NameDto>(nameModel);

            Console.WriteLine(nameDto3.AllName);
        }
        /// <summary>
        /// 4.属性条件转换
        /// </summary>
        public static void MapperByPropertyCondition()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };
            Mapper.CreateMap<Name, NameDto>()
            .ForMember(name => name.FirstName, opt => opt.Condition(name => !name.FirstName.Equals("l", StringComparison.OrdinalIgnoreCase)));
            NameDto nameDto4 = Mapper.Map<Name, NameDto>(nameModel);
            Console.WriteLine(string.IsNullOrEmpty(nameDto4.FirstName));
        }

        public static void PropertyIgnore()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };
            Mapper.CreateMap<Name, NameDto>()
            .ForMember(name => name.FirstName, opt => opt.Ignore());
            NameDto nameDto5 = Mapper.Map<Name, NameDto>(nameModel);
            Console.WriteLine(string.IsNullOrEmpty(nameDto5.FirstName));
        }
        /// <summary>
        /// 6.属性转换
        /// </summary>
        public static void MapperByProperty()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };

            Mapper.CreateMap<Name, NameDto>()
            .ForMember(name => name.AllName, opt => opt.MapFrom(name => name.FirstName + name.LastName))
            .ForMember(name => name.FirstName, opt => opt.MapFrom(name => name.FirstName));

            NameDto nameDto6 = Mapper.Map<Name, NameDto>(nameModel);
            Console.WriteLine(nameDto6.AllName);
            Console.WriteLine();
        }
        /// <summary>
        /// 7.属性通过ValueResolver转换
        /// </summary>
        public static void ValueResolver()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };

            Mapper.CreateMap<Name, StoreDto>()
            .ForMember(storeDto => storeDto.Name, opt => opt.ResolveUsing<NameResolver>());
            StoreDto store1 = Mapper.Map<Name, StoreDto>(nameModel);

            Console.WriteLine(store1.Name.FirstName + store1.Name.LastName);
        }
        /// <summary>
        /// 8.属性填充固定值
        /// </summary>
        public static void FillFixedValueToProperty()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };
            Mapper.CreateMap<Name, NameDto>()
            .ForMember(name => name.AllName, opt => opt.UseValue<string>("ljzforever"));
            NameDto nameDto8 = Mapper.Map<Name, NameDto>(nameModel);
            Console.WriteLine(nameDto8.AllName);
        }
        /// <summary>
        /// 9.属性格式化
        /// </summary>
        public static void ProperyFormat()
        {
            Name nameModel = new Name() { FirstName = "李", LastName = "宽" };

            Mapper.CreateMap<Name, NameDto>()
            .ForMember(name => name.FirstName, opt => opt.AddFormatter<StringFormatter>());
            NameDto nameDto9 = Mapper.Map<Name, NameDto>(nameModel);
            Console.WriteLine(nameDto9.FirstName);
        }
        /// <summary>
        /// 10.属性null时的默认值
        /// </summary>
        public static void PropertyValueIsNullDefaultValue()
        {
            Name nameModel = new Name() { FirstName = "李" };

            Mapper.CreateMap<Name, NameDto>()
            .ForMember(name => name.LastName, opt => opt.NullSubstitute("宽"));
            NameDto nameDto10 = Mapper.Map<Name, NameDto>(nameModel);

            Console.WriteLine(nameDto10.LastName);
        }
        /// <summary>
        /// 11.转换匿名对象
        /// </summary>
        public static void MapperAnonymityObject()
        {
            object name11 = new { FirstName = "李", LastName = "宽" };
            NameDto nameDto11 = Mapper.DynamicMap<NameDto>(name11);

            Console.WriteLine(nameDto11.FirstName + nameDto11.LastName);
        }
        /// <summary>
        /// 12.转换DataTable
        /// </summary>
        public static void DataTableMapper()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Rows.Add("李", "宽");
            List<NameDto> nameDto12 = Mapper.DynamicMap<IDataReader, List<NameDto>>(dt.CreateDataReader());
            Console.WriteLine(nameDto12[0].FirstName + nameDto12[0].LastName);

        }
        /// <summary>
        /// 转化存在的对象
        /// </summary>
        public static void ExistOjectMapper()
        {
            Mapper.CreateMap<Name, NameDto>()
         .ForMember(name => name.LastName, opt => opt.Ignore());
            Name nameModel = new Name() { FirstName = "李" };
            NameDto nameDto = new NameDto() { LastName = "宽" };
            Mapper.Map<Name, NameDto>(nameModel, nameDto);
            //nameDto13 = Mapper.Map<Name, NameDto>(name13);//注意,必需使用上面的写法,不然nameDto13对象的LastName属性会被覆盖
            Console.WriteLine(nameDto.FirstName + nameDto.LastName);
        }
        /// <summary>
        /// Flatten特性 Store.Name.FirtName=FlattenName.NameFirstname
        /// </summary>
        public static void FlatterMapper()
        {
            Mapper.CreateMap<Store, FlattenName>();
            Store store2 = new Store() { Name = new Name() { FirstName = "李", LastName = "宽" } };
            FlattenName nameDto14 = Mapper.Map<Store, FlattenName>(store2);
            Console.WriteLine(nameDto14.NameFirstname + nameDto14.NameLastName);
        }
        /// <summary>
        /// 将Dictionary转化为对象,现在还不支持
        /// </summary>
        public static void DictionaryMapper()
        {
            Mapper.CreateMap<Dictionary<string, object>, Name>();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("FirstName", "L");
            //Name name15 = Mapper.DynamicMap<Dictionary<string, object>, Name>(dict);
            Name name15 = Mapper.Map<Dictionary<string, object>, Name>(dict);
            Console.WriteLine(name15.FirstName);
        }
        #endregion
        #region

        public static void InitializeMapper()
        {
            Article article = new Article
            {
                Title = "title",
                Content = "Content",
                Author = "nongfu",
                PostTime = DateTime.Now,
                Remark = "remark"
            };
            //配置AutoMapper 
            Mapper.Initialize(p =>
            {
                p.CreateMap<Article, ArticleDto>()//创建映射
               .ForMember(dest => dest.ArticleID, opt => opt.MapFrom(src => src.Id))//指定映射规则
               .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Content.Substring(0, 10)))//指定映射规则
               .ForMember(dest => dest.PostYear, opt => opt.MapFrom(src => src.PostTime.Year))//指定映射规则
               .ForMember(dest => dest.Remark, opt => opt.Ignore());//指定映射规则 忽视没有的属性
            });

            //调用映射
            ArticleDto form = Mapper.Map<Article, ArticleDto>(article);
        }

        #endregion
    }
}
