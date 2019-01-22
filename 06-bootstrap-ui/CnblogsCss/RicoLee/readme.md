#markdown解析与着色

## 简介

最近在调整博客园博客样式,使用markdown发表的博客。这个不要太好用,`有道云`+`markdown`简直绝配,可以发在任何支持markdwon的博客网站,样式基本不会走形，博客园对自定义样式也支持的很好。之前写过一个篇[博客园对markdown语法的支持](https://www.cnblogs.com/ricolee/p/markdown.html)可以看到效果。

代码怎么像这样的效果呢？  
![image](https://raw.githubusercontent.com/rocklee2015/BlogImg/master/2018/181223-highlightjs-pre.png)  
其实很简单就是**解析**+**着色**

## markdown解析

markdown的解析暂时查到就有四种`javascript`库：  

1. `marked`  
2. `mdjs`
3. `HyperDown`
4. `strapdown`

而这四种插件的使用也很简单,引用好`js`库后直接解析加载的markdwon文件将其放入document中就ok,javascript代码如下：

```js
$.ajax({
    type: "get",
    //url: "/Content/markdown/demo.md",
    url: "@Url.Action("MarkdonwFile")",
    async: false,
    dataType: "text",
    success: function (response, status, request) {
        $('#mdjsDemo').html(Mdjs.md2html(response));//mdjs
        $('#markedDemo').html(marked(response)); //marked
        var parser = new HyperDown;
        $('#hyperDownDemo').html(parser.makeHtml(response));//HyperDown
    }
});
```

由于ajax不能直接请求md文件,暂时不知道什么原因先不理会,服务器代码如下：

```cs
public ActionResult MarkdonwFile()
{
    //返回markdown文件
    var mk = AppDomain.CurrentDomain.BaseDirectory + "Content/markdown/demo.md";
    return File(mk,"text/plain");
}
```

效果如下：  
![解析好的markdown](https://raw.githubusercontent.com/rocklee2015/BlogImg/master/2018/181224-markdown-parse.gif)

## highlight 着色

`markdown`经解析后其中code是html默认的样式黑白两色，看着不舒服,可以试用`highlight`进行着色。  
`highlight`的使用也非常简单引用库并调用*hljs.initHighlightingOnLoad()*即可,代码如下：

```xml
<script src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/highlight.min.js"></script>
<script>
    hljs.initHighlightingOnLoad()
</script>
```

highlight支持着色的语言非常多,样式也很很丰富。

## highlight 动态着色

效果如下：  
![highlight 样式切换](https://raw.githubusercontent.com/rocklee2015/BlogImg/master/2018/181224-highlightjs-style.gif)

在`cdnjs`上可以获取`highlight`的js脚本和css样式，可是css样式很多一个个粘贴很麻烦。所以想了个方法自动生成`<option></option>`项。

在[cdnjs的highlight库](https://cdnjs.com/libraries/highlight.js)上可以看到js和css是一个如下列表:  
![highlight 风格css获取](https://raw.githubusercontent.com/rocklee2015/BlogImg/master/2018/181223-highlightjs-css-get.png)

简单分析后，可以用如下代码拼接所有的`option`项

```js
$('.library-url').toArray().filter(item = >{
    return $(item).html().endsWith('.css')
}).reduce((tmp, item) = >{
    return tmp + '<option value="' + $(item).html() + '">' + $(item).html().substr($(item).html().lastIndexOf('/') + 1) + '</option>'
})
```

效果如下：  
![样式获取结果](https://raw.githubusercontent.com/rocklee2015/BlogImg/master/2018/181223-highlightjs-css-result.png)

## 参考

- [前端解析Markdown](https://www.cnblogs.com/vmask/p/6666011.html)
- [markedjs 源码](https://github.com/markedjs/marked)
- [HyperDown 源码](https://github.com/SegmentFault/HyperDown.js)