/*
* @Author: Rosen
* @Date:   2017-05-19 17:39:14
* @Last Modified by:   Rosen
* @Last Modified time: 2017-05-24 16:46:02
*/
document.write("<script src='../util/mm.js'></script>");

//var templateIndex   = require('./index.string');
// 侧边导航
var navSide = {
    option : {
        name : '',
        navList : [
            {name : 'user-center', desc : '个人中心', href: './UserCenter'},
            {name : 'order-list', desc : '我的订单', href: '/Order/OrderList'},
            { name: 'user-pass-update', desc: '修改密码', href: './UserPassUpdate'},
            {name : 'about', desc : '关于MMall', href: './About'}
        ]
    },
    init : function(option){
        // 合并选项
        $.extend(this.option, option);
        this.renderNav();
    },
    // 渲染导航菜单
    renderNav: function () {
        var html = "";
        // 计算active数据
        for(var i = 0, iLength = this.option.navList.length; i < iLength; i++){
            if (this.option.navList[i].name === this.option.name) {
                // this.option.navList[i].isActive = true;
                html += '<li class="nav-item active"><a class="link" href = "' + this.option.navList[i].href + '" > ' + this.option.navList[i].desc + '</a ></li >';
            } else {
                html += '<li class="nav-item"><a class="link" href = "' + this.option.navList[i].href + '" > ' + this.option.navList[i].desc + '</a ></li >';
            }
            console.log(html)
        };

        //// 渲染list数据
        //var navHtml = _mm.renderHtml(templateIndex, {
        //    navList : this.option.navList
        //});
        //// 把html放入容器
        //$('.nav-side').html(navHtml);
        $('.nav-side').append(html);
    }
};

//module.exports = navSide;