/**
 * 注册流程 公用js
 * @authors Your Name (you@example.org)
 * @date    2014-08-13 10:55:02
 * @version $Id$
 */
var Tools = new Object();

//信息string
Tools.message = {
    username: "账号不能为空!",
    password: "密码不能为空!",
     confirm: "密码不能重复",
twiceConfirm: "两次密码输入不一致",
    protocal: "您还没同意协议",
    vericode: "验证码不能为空"
};
/**
 * 得到当前对象
 * @param    obj e 事件源
 * @return   obj   对象
 */
Tools.srcElement = function(e)
{
    return document.all ? e.srcElement :e.target;
}
/**
 * 聚焦事件
 * @param     obj e   事件源
 * @param  string msg 提示信息
 */
Tools.focus = function(e,msg)
{
    var obj = this.srcElement(e);
    if(obj.value == msg)
    {
       obj.value = "";
    }
}
/**
 * 失去聚焦事件
 * @param     obj e   事件源
 * @param  string msg 提示信息
 */
Tools.blur = function(e,msg)
{
    var obj = this.srcElement(e);
    if(obj.value == "")
    {
      alert(msg);
    }
}

