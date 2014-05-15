/**
 * 焦点查询关键词
 * 
 * @param {type} keyword
 * @returns {undefined}
 * 
 * @Author guan
 */

function lookup(keyword)
{
    var category_list = document.getElementById('category');
    var suggestions = document.getElementById('suggestions');
    var auto_suggestions_list = document.getElementById('auto_suggestions_list');
	var category = document.getElementById('text').innerHTML;
    if(keyword.length == 0)
    {
        //隐藏建议框
        suggestions.style.display = 'none';
    }
    else
    {
        $.ajax({
		   type: "POST",
		   url: "suggestions2.php",
		   data: "category=" + category + "&keyword=" + keyword,
		   success: function(msg){
			 if(msg)
			 {
				suggestions.style.display = 'block';
				auto_suggestions_list.innerHTML = msg;
			 }
		   }
		});
    }
    document.documentElement.onkeyup = keyup;
}




function change_suggestions_response(res)
{
    var suggestions = document.getElementById('suggestions');
    var auto_suggestions_list = document.getElementById('auto_suggestions_list');
    if(res.option)
    {
        suggestions.style.display = 'block';
        auto_suggestions_list.innerHTML = res.option;
    }
    else
    {
        auto_suggestions_list.innerHTML = 'error';
    }
}

/**
 * 按键查询关键字
 * 
 * @type Number|Number|Number|@exp;li@pro;length
 * 
 * @author guan
 */
index = 0; //初始化索引
function keyup(e)
{
    var keyword = document.getElementById('keyword').value;
    var suggestions = document.getElementById('suggestions');
    var category_list = document.getElementById('category');
    var auto_suggestions_list = document.getElementById('auto_suggestions_list');
	var category = document.getElementById('text').innerHTML;
    //var category = category_list.options[category_list.selectedIndex].value;
    e = window.event || e;
    if(40 == e.keyCode) //按键盘向下键
    {
        var li = document.getElementById('suggestions_list_id').getElementsByTagName('li');
		if(index == 1)
		{
			index++;
		}
        setView(li, index, li[index].innerHTML);
        if(++index == li.length) { index = 0; }
    }
    else if(38 == e.keyCode)//按键盘向上键
    {
        var li = document.getElementById('suggestions_list_id').getElementsByTagName('li');
        if(--index == -1) { index = li.length-1; }
		if(index == 1)
		{
			index--;
		}
        setView(li, index, li[index].innerHTML);
    }
    else
    {
        if(keyword.length == 0)
        {
            //隐藏建议框
            suggestions.style.display = 'none';
        }
        else
        {
			$.ajax({
			   type: "POST",
			   url: "suggestions2.php",
			   data: "category=" + category + "&keyword=" + keyword,
			   success: function(msg){
				 if(msg)
				 {
					suggestions.style.display = 'block';
					auto_suggestions_list.innerHTML = msg;
				 }
			   }
			});
        }
    }
}

/**
 * 设置背景颜色
 * 
 * @param {string} elems
 * @param {string} index
 * @returns {undefined}
 * 
 * @Author guan
 */
function setView(elems, index, str)
{
    var input_obj = document.getElementById('keyword');
    for(var j=0; j<elems.length; j++)
    {
        elems[j].style.background = '';
    }
    elems[index].style.background = '#ffdfc6';
	
	var str_word = '<span class="suggest_span">';
    str = str.substr(0, str.indexOf(str_word));
    str = str.replace(/<[^>]+>/g,"");
    str = str.replace('&nbsp;', ' ');
    input_obj.value = str;
}

/**
 * 隐藏提示框，并提交搜索
 * 
 * @param {type} this_value
 * @returns {undefined}
 * 
 * @author guan
 */
function fill(this_value)
{
    document.documentElement.onkeyup = false;
    var keyword = document.getElementById('keyword');
    var suggestions = document.getElementById('suggestions');
    setTimeout("suggestions.style.display='none'", 100);
    if(this_value)
    {
        keyword.value = this_value;
        document.getElementById('searchForm').submit();
    }
}

function _over(li)
{
    var li_list = document.getElementById('suggestions_list_id').getElementsByTagName('li');
    for(var i=0, len=li_list.length; i<len; i++)
    {
        li_list[i].style.background = '';
        li.style.cursor = '';
    }
    li.style.background = '#ffdfc6';
    li.style.cursor = 'pointer';
}

function _out(li)
{
    li.style.background = '';
    li.style.cursor = '';
}