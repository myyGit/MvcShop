$(function () {
    //page.init();
    $(".user-addresslist").click(function () {
        $(this).addClass("defaultAddr").siblings().removeClass("defaultAddr");
        
    });
    $(".setDefault").click(function () {
        console.log("aa")
        $(".setDefault").removeClass("hidden");
        $(".setDefaultLine").removeClass("hidden");
        $(".deftip").addClass("hidden");
        $(this).parent(".new-addr-btn").siblings(".address-left").find(".deftip").removeClass("hidden");
        $(this).addClass("hidden");
        $(this).next().addClass("hidden");
       // $(this).parents(".user-addresslist").siblings().
       // $(this).parents("user-addresslist").addClass("defaultAddr").siblings().removeClass("defaultAddr");
    })
    $(".logistics").each(function () {
        var i = $(this);
        var p = i.find("ul>li");
        p.click(function () {
            if (!!$(this).hasClass("selected")) {
                $(this).removeClass("selected");
            } else {
                $(this).addClass("selected").siblings("li").removeClass("selected");
            }
        })
    })
    var $ww = $(window).width();

    $('.createAddr').click(function () {
        console.log("进来")
        //禁止遮罩层下面的内容滚动
        $(document.body).css("overflow", "hidden");
        //$(this).addClass("selected");
        //$(this).parent().addClass("selected");
        $('.theme-popover-mask').show();
        $('.theme-popover-mask').height($(window).height());
        $('.theme-popover').slideDown(200);

    })

    $('.theme-poptit .close,.btn-op .close').click(function () {

        $(document.body).css("overflow", "visible");
        $('.theme-login').removeClass("selected");
        $('.item-props-can').removeClass("selected");
        $('.theme-popover-mask').hide();
        $('.theme-popover').slideUp(200);
    })
})