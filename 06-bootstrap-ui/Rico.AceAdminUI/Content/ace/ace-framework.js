/*
水云间网络科技 @ copryright
*/
(function () {
    sidebar();
})();

/**
新菜单根据Url决定样式
*/
function sidebar() {
    var locationHref = window.location.href;
    $(".submenu  li a").each(function () {
        if (locationHref.indexOf($(this).attr("href")) > 0) {
            //将所有父级元素添加展开和激活样式，然后再去除最近一个父级元素的open样式
            $(this).parents("li").addClass("open active");
            $(this).parent().removeClass("open");
        }
    });

}
