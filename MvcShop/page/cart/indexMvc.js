
document.write("<script src='../util/mm.js'></script>");
document.write("<script src='../service/user-service.js'></script>");
document.write("<script src='../service/cart-service.js'></script>");
document.write("<script src='../page/common/nav/index.js'></script>");

var page = {
    data : {
        
    },
    init : function(){
        this.onLoad();
        this.bindEvent();
    },
    onLoad : function(){
        this.loadCart();
    },
    bindEvent : function(){
        var _this = this;
        // 商品的选择 / 取消选择
        $(document).on('click', '.cart-select', function(){
            var $this = $(this);
            var productId = $this.parents('.cart-table').data('product-id');
            if ($(".cart-list input:checkbox").length === $(".cart-list input:checked").length) {
                $(".cart-select-all").prop("checked", true);
            } else {
                $(".cart-select-all").prop("checked", false);
            }
            _this.JudgeCount();
        });
        // 商品的全选 / 取消全选
        $(document).on('click', '.cart-select-all', function(){
            $(".cart-select-all").prop("checked", $(this).prop('checked'));
            $(".cart-list input:checkbox").prop("checked", $(this).prop('checked'));
            _this.JudgeCount();
        });
        // 商品数量的变化
        $(document).on('click', '.count-btn', function(){
            var $this       = $(this),
                $pCount     = $this.siblings('.count-input'),
                currCount   = parseInt($pCount.val()),
                type        = $this.hasClass('plus') ? 'plus' : 'minus',
                productId   = $this.parents('.cart-table').data('product-id'),
                minCount    = 1,
                maxCount = parseInt($pCount.data('max')),
                newCount = 0;
            if(type === 'plus'){
                if(currCount >= maxCount){
                    _mm.errorTips('该商品数量已达到上限');
                    return;
                }
                newCount = currCount + 1;
            }else if(type === 'minus'){
                if(currCount <= minCount){
                    return;
                }
                newCount = currCount - 1;
            }
            var price = parseInt($pCount.parent().siblings(".cell-price").html().replace("￥", ""));
            $pCount.parent().siblings(".cell-total").html(price * newCount);
            $pCount.val(newCount);
            _this.JudgeCount();
            // 更新购物车商品数量
            _cart.updateProduct({
                productId: productId,
                count: newCount
            }, function (res) {
                //_this.renderCart(res);
                }, function (errMsg) {
                    console.log(errMsg)
                _this.showCartError();
            });
        });
        // 删除单个商品
        $(document).on('click', '.cart-delete', function(){
            if(window.confirm('确认要删除该商品？')){
                var productId = $(this).parents('.cart-table')
                    .data('product-id');
                _this.deleteCartProduct(productId);
            }
        });
        // 删除选中商品
        $(document).on('click', '.delete-selected', function(){
            if(window.confirm('确认要删除选中的商品？')){
                var arrProductIds = [],
                    $selectedItem = $('.cart-select:checked');
                // 循环查找选中的productIds
                for(var i = 0, iLength = $selectedItem.length; i < iLength; i ++){
                    arrProductIds
                        .push($($selectedItem[i]).parents('.cart-table').data('product-id'));
                }
                if(arrProductIds.length){
                    _this.deleteCartProduct(arrProductIds.join(','));
                }
                else{
                    _mm.errorTips('您还没有选中要删除的商品');
                }  
            }
        });
        // 提交购物车
        $(document).on('click', '.btn-submit', function(){
            // 总价大于0，进行提交
            if(_this.data.cartInfo && _this.data.cartInfo.cartTotalPrice > 0){
                window.location.href = './confirm.html';
            }else{
                _mm.errorTips('请选择商品后再提交');
            }
        });
    },
    // 加载购物车信息
    loadCart : function(){
        
    },
    JudgeCount : function () {
        var heJi = 0;
        $('.cart-list input[type=checkbox]:checked').each(function () {
            var aa = $(this).parents('.cart-table').eq(0).find(".cell-total").each(function (e) {
                var total = parseInt($(this).html().replace("￥", ""))
                heJi = heJi + total;
            })
        })
        $(".submit-total").html("￥" + heJi)
    },
    // 渲染购物车
    renderCart : function(data){
        this.filter(data);
        // 缓存购物车信息
        this.data.cartInfo = data;
        // 生成HTML
        //var cartHtml = _mm.renderHtml(templateIndex, data);
        //$('.page-wrap').html(cartHtml);
        // 通知导航的购物车更新数量
        nav.loadCartCount();
    },
    // 删除指定商品，支持批量，productId用逗号分割
    deleteCartProduct : function(productIds){
        var _this = this;
        _cart.deleteProduct(productIds, function(res){
            //_this.renderCart(res);
            //location.replace(document.referrer);
            window.location.href = "/Cart/List";
        }, function (errMsg) {
            console.log(errMsg);
            _this.showCartError();
        });
    },
    // 数据匹配
    filter : function(data){
        data.notEmpty = !!data.cartProductVoList.length;
    },
    // 显示错误信息
    showCartError: function(){
        $('.page-wrap').html('<p class="err-tip">哪里不对了，刷新下试试吧。</p>');
    }
};
$(function(){
    page.init();
})