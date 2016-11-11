using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.Spider.Tmall
{
    public class Data
    {
        public int pageSize { get; set; }
        public int totalPage { get; set; }
        public int currentPage { get; set; }
        public int totalCount { get; set; }
    }

    public class Pager
    {
        public string status { get; set; }
        public Data data { get; set; }
        public bool export { get; set; }
    }

    public class Data2
    {
        public bool render { get; set; }
        public bool useOld { get; set; }
        public string showType { get; set; }
    }

    public class Feedback
    {
        public string status { get; set; }
        public Data2 data { get; set; }
        public bool export { get; set; }
    }

    public class Noresult
    {
        public string status { get; set; }
        public bool export { get; set; }
    }

    public class Updatebar
    {
        public string status { get; set; }
        public bool export { get; set; }
    }

    public class Handpick
    {
        public string status { get; set; }
        public bool export { get; set; }
    }

    public class Data3
    {
        public string keyword { get; set; }
        public int pageNum { get; set; }
        public string frontcatid { get; set; }
        public int total { get; set; }
        public string keywordGBK { get; set; }
    }

    public class P4p
    {
        public string status { get; set; }
        public Data3 data { get; set; }
        public bool export { get; set; }
    }

    public class SortList
    {
        public string name { get; set; }
        public string tip { get; set; }
        public bool isActive { get; set; }
        public string value { get; set; }
        public string key { get; set; }
    }

    public class SubType
    {
        public string level { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class TypeList
    {
        public string shopType { get; set; }
        public List<SubType> subType { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class ShopType
    {
        public string show { get; set; }
        public List<TypeList> typeList { get; set; }
    }

    public class Location
    {
        public string active { get; set; }
        public string guessLoc { get; set; }
        public List<object> usualLoc { get; set; }
    }

    public class ReleField
    {
        public string type { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class ReleFields
    {
        public string show { get; set; }
        public List<ReleField> releField { get; set; }
    }

    public class Pager2
    {
        public int pageSize { get; set; }
        public int totalPage { get; set; }
        public int currentPage { get; set; }
        public int totalCount { get; set; }
    }

    public class Filter
    {
        public bool isActive { get; set; }
        public string value { get; set; }
        public string title { get; set; }
        public string key { get; set; }
        public string trace { get; set; }
    }

    public class GoodrateList
    {
        public string rate { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Goodrates
    {
        public string show { get; set; }
        public List<GoodrateList> goodrateList { get; set; }
    }

    public class Data4
    {
        public List<SortList> sortList { get; set; }
        public ShopType shopType { get; set; }
        public Location location { get; set; }
        public ReleFields releFields { get; set; }
        public Pager2 pager { get; set; }
        public List<Filter> filters { get; set; }
        public Goodrates goodrates { get; set; }
    }

    public class Sortbar
    {
        public string status { get; set; }
        public Data4 data { get; set; }
        public bool export { get; set; }
    }

    public class AuctionsInshop
    {
        public string nid { get; set; }
        public string picUrl { get; set; }
        public string title { get; set; }
        public string price { get; set; }
        public string url { get; set; }
        public string uid { get; set; }
    }

    public class ShopIcon
    {
        public string trace { get; set; }
        public string iconClass { get; set; }
        public string url { get; set; }
        public string title { get; set; }
    }

    public class DsrInfo
    {
        public string mgDomClass { get; set; }
        public string dsrStr { get; set; }
        public string cgDomClass { get; set; }
        public string sgDomClass { get; set; }
    }

    public class CouponList
    {
        public string url { get; set; }
        public string startFee { get; set; }
        public string value { get; set; }
    }

    public class ShopItem
    {
        public string uid { get; set; }
        /// <summary>
        /// 商家名
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string provcity { get; set; }
        /// <summary>
        /// 总销量
        /// </summary>
        public int totalsold { get; set; }
        public int procnt { get; set; }
        public string encodeNick { get; set; }
        public string goodratePercent { get; set; }
        public string dynamic { get; set; }
        private string _shopUrl;
        /// <summary>
        /// 店铺地址
        /// </summary>
        public string shopUrl { get { return "https:" + _shopUrl; } set { _shopUrl = value; } }
        public string similarUrl { get; set; }
        public string picUrl { get; set; }
        public string rawTitle { get; set; }
        public bool hasMoreAuctions { get; set; }
        public string mainAuction { get; set; }
        public string userRateUrl { get; set; }
        public bool isTaojinbi { get; set; }
        public string taojinbiRate { get; set; }
        public bool isManjian { get; set; }
        public bool isSongli { get; set; }
        public bool isTmall { get; set; }
        public bool hasSimilar { get; set; }
        public List<AuctionsInshop> auctionsInshop { get; set; }
        public ShopIcon shopIcon { get; set; }
        public string nid { get; set; }
        public bool isMianyou { get; set; }
        public string startFee { get; set; }
        public string discountCash { get; set; }
        public string giftName { get; set; }
        public bool isHideSale { get; set; }
        public List<object> icons { get; set; }
        public DsrInfo dsrInfo { get; set; }
        public List<CouponList> couponList { get; set; }
    }

    public class Data5
    {
        public List<ShopItem> shopItems { get; set; }
        public string apiUrl { get; set; }
        public string q { get; set; }
    }

    public class Shoplist
    {
        public string status { get; set; }
        public Data5 data { get; set; }
        public bool export { get; set; }
    }

    public class Sc
    {
        public string status { get; set; }
        public bool export { get; set; }
    }

    public class Data6
    {
        public int totalHits { get; set; }
        public bool isSimilar { get; set; }
    }

    public class Tab
    {
        public string status { get; set; }
        public Data6 data { get; set; }
        public bool export { get; set; }
    }

    public class Debugbar
    {
        public string status { get; set; }
        public bool export { get; set; }
    }

    public class TabParams
    {
        public string js { get; set; }
        public string initiative_id { get; set; }
        public string ie { get; set; }
    }

    public class Dropdown
    {
        public string url { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool isActive { get; set; }
    }

    public class Data7
    {
        public string q { get; set; }
        public TabParams tabParams { get; set; }
        public List<Dropdown> dropdown { get; set; }
    }

    public class Header
    {
        public string status { get; set; }
        public Data7 data { get; set; }
        public bool export { get; set; }
    }

    public class Mods
    {
        public Pager pager { get; set; }
        public Feedback feedback { get; set; }
        public Noresult noresult { get; set; }
        public Updatebar updatebar { get; set; }
        public Handpick handpick { get; set; }
        public P4p p4p { get; set; }
        public Sortbar sortbar { get; set; }
        public Shoplist shoplist { get; set; }
        public Sc sc { get; set; }
        public Tab tab { get; set; }
        public Debugbar debugbar { get; set; }
        public Header header { get; set; }
    }

    public class ModLinks
    {
        public string pager { get; set; }
        public string @default { get; set; }
        public string sortbar { get; set; }
        public string nav { get; set; }
        public string tab { get; set; }
        public string filter { get; set; }
        public string breadcrumb { get; set; }
    }

    public class SrpGlobal
    {
        public string q { get; set; }
        public string encode_q { get; set; }
        public string utf8_q { get; set; }
        public string cat { get; set; }
        public int s { get; set; }
        public string tnk { get; set; }
        public int bucketid { get; set; }
        public string multi_bucket { get; set; }
        public string machine { get; set; }
        public string buckets { get; set; }
        public string sp_url { get; set; }
        public string srpName { get; set; }
        public string alg_bts { get; set; }
    }

    public class TraceData
    {
        public string page_size { get; set; }
        public string cat { get; set; }
        public string at_bucketid { get; set; }
        public string sort { get; set; }
        public string rn { get; set; }
        public string lastAlitrackid { get; set; }
        public string bucketId { get; set; }
        public string query { get; set; }
        public string qp_bury { get; set; }
        public string at_lflog { get; set; }
        public string if_tank { get; set; }
        public string at_host { get; set; }
        public string remoteip { get; set; }
        public string alitrackid { get; set; }
        public string alg_bts { get; set; }
        public List<string> uids { get; set; }
        public string catpredict_bury { get; set; }
        public string totalHits { get; set; }
        public string catdirectForMaidian { get; set; }
        public string multivariate { get; set; }
        public string statsClick { get; set; }
        public string noResultCode { get; set; }
        public string colo { get; set; }
        public string at_colo { get; set; }
        public string multi_bucket { get; set; }
        public string rewrite_bury { get; set; }
        public string querytype_bury { get; set; }
        public string hostname { get; set; }
        public string catLevelOne { get; set; }
        public string sort2 { get; set; }
        public string spurl { get; set; }
        public string nick { get; set; }
        public string goodrate { get; set; }
        public string pre { get; set; }
        public string stype { get; set; }
        public string q { get; set; }
        public string srppage { get; set; }
    }

    public class TraceInfo
    {
        public string pvStat { get; set; }
        public TraceData traceData { get; set; }
    }

    public class MainInfo
    {
        public string currentUrl { get; set; }
        public ModLinks modLinks { get; set; }
        public SrpGlobal srpGlobal { get; set; }
        public TraceInfo traceInfo { get; set; }
        public List<object> remainMods { get; set; }
    }

    public class Feature
    {
        public bool retinaOff { get; set; }
        public bool shopcardOff { get; set; }
        public bool webpOff { get; set; }
    }

    public class Map
    {
    }

    public class RootObject
    {
        public string pageName { get; set; }
        public Mods mods { get; set; }
        public MainInfo mainInfo { get; set; }
        public Feature feature { get; set; }
        public Map map { get; set; }
    }
}
