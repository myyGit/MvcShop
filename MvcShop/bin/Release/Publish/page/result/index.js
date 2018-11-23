document.write("<script src='../util/mm.js'></script>");
document.write("<script src='../page/common/nav-simple/index.js'></script>");

$(function(){
    var type        = _mm.getUrlParam('type') || 'default',
        $element    = $('.' + type + '-success');
    // 显示对应的提示元素
    $element.show();
})