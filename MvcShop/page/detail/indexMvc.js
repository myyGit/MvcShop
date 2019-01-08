/*
* @Author: Rosen
* @Date:   2017-05-28 19:45:49
* @Last Modified by:   Rosen
* @Last Modified time: 2017-05-29 18:39:01
*/
document.write("<script src='../util/mm.js'></script>");
document.write("<script src='../service/cart-service.js'></script>");

window.onload = function bb() {
    var productId = parseInt(getQueryString("productId"));
    if (isNaN(productId) || productId == null || productId <= 0) {
        window.history(-1);
    }
    //console.log("productId=" + productId)
}
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
var page = {
    data: {
        productId: parseInt(getQueryString("productId")) || '',
    },
    init: function () {
        this.onLoad();
        this.bindEvent();
    },
    onLoad: function () {
        // 如果没有传productId, 自动跳回首页
        //if (!this.data.productId) {
        //    _mm.goHome();
        //}
        //this.loadDetail();
    },
    bindEvent: function () {
        var _this = this;
        // count的操作
        $(document).on('click', '.p-count-btn', function () {
            var type = $(this).hasClass('plus') ? 'plus' : 'minus';
            var currCount = parseInt($('.p-count').val());
            var minCount = 1;
            var maxCount = parseInt($('.struct').html());
            if (type === 'plus' && currCount < maxCount) {
                $('.p-count').val(currCount < maxCount ? currCount + 1 : maxCount);
            }
            else if (type === 'minus' && currCount > 1) {
                $('.p-count').val(currCount > minCount ? currCount - 1 : minCount);
            }
        });
        // 加入购物车
        $(document).on('click', '.cart-add', function () {
            _cart.addToCart({
                productId: _this.data.productId,
                count: parseInt($('.p-count').val())
            }, function (res) {
                window.location.href = '/Home/result?type=cart-add';
            }, function (errMsg) {
                console.log(errMsg)
                _mm.errorTips(errMsg);
            });
        });
        // 图片预览
        $(document).on('mouseenter', '.p-img-item', function () {
            var imageUrl = $(this).find('.p-img').attr('src');
            $('.main-img').attr('src', imageUrl);
        });
    }
};
$(function () {
    page.init();
})