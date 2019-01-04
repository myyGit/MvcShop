document.write("<script src='../util/mm.js'></script>");
document.write("<script src='../page/common/nav-side/index.js'></script>");
document.write("<script src='../service/user-service.js'></script>");


// page 逻辑部分
var page = {
    init: function(){
        this.onLoad();
    },
    onLoad : function(){
        // 初始化左侧菜单
        navSide.init({
            name: 'user-center'
        });
        // 加载用户信息
        this.loadUserInfo();
    },
    // 加载用户信息
    loadUserInfo : function(){
        //var userHtml = '';
        //_user.getUserInfo(function(res){
        //    userHtml = _mm.renderHtml(templateIndex, res);
        //    $('.panel-body').html(userHtml);
        //}, function(errMsg){
        //    _mm.errorTips(errMsg);
        //});
    }
};
$(function(){
    page.init();
});