///*
//* @Author: Rosen
//* @Date:   2017-05-08 15:19:12
//* @Last Modified by:   Rosen
//* @Last Modified time: 2017-05-26 19:36:18
//*/

//'use strict';
//require('./index.css');
//require('page/common/nav/index.js');
//require('page/common/header/index.js');
//require('util/slider/index.js');
//var navSide         = require('page/common/nav-side/index.js');
//var templateBanner  = require('./banner.string');
//var _mm             = require('util/mm.js');
var arrays = ["/image/banner/banner1.jpg", "/image/banner/banner2.jpg", "/image/banner/banner3.jpg", "/image/banner/banner4.jpg", "/image/banner/banner5.jpg"];
var index = 1; //保存图片当前下标
 //延迟加载
$(function () {
    //$(function () {
        for (var i = 0; i < arrays.length; i++) {
            $(".banner-con").append("<a href='#'> <img  width='100%' height='100%' src='" + arrays[i] + "' /></a>");
            //几个图片 几个按钮 循环5次
            $("#span_btn").append("<span name='" + (i + 1) + "'>&bull;</span>")
        }
        $("#span_btn span").eq(0).addClass("active");
        $("banner-con img").hide().eq(0).show();
        $("#span_btn span").click(function () {
            index = parseInt($(this).attr("name")) - 1;
            $(".banner-con img").hide().eq(index).show();
            $(this).addClass("active").siblings().removeClass("active");
        });
        $(".banner-con img").mouseover(function () {
            //清除定时器
            clearInterval(c);
        })
        $(".banner-con img").mouseout(function () {
            //重新定义定时器
            c = setInterval("changeImage()", 2000);
        })
    //})
});
var c = setInterval("changeImage()", 2000);//每隔2秒调用一次函数
function changeImage() {
    //自动的隐藏显示
    $(".banner-con img").hide().eq(index).show();
    $("#span_btn span").eq(index)
        .addClass("active").siblings().removeClass("active");
    index += 1;
    var length = $(".banner-con img").length;
    if (index >= arrays.length) {
        index = 0;
    }
}
