<%@ Page Title="添加试卷" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPaper.aspx.cs" Inherits="Exam_AddTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/customer.css" />
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script> 
    <script type="text/javascript" src="../js/bootstrap.js"></script> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth">
      <div class="setRigthContent">
          <div class="title" style="font-size:20px">添加试卷</div>
          <div style="width:100%;height:1px;border:2px solid #464d77;background-color:#464d77"></div>
          <div class="topSelDiv">
          <div class="title">试卷数据</div>
          <div class="topContent" style="background-color:#e9e9e9">
            <div style="height:30px;">试卷名称：
              <input type="text" class="" name="paper_name" style="width:300px;" />
            </div>
            <div>试卷分类：<a href="./SF_files/paper_add.html" id="selTypeLink"><span>选择分类</span> <img src="../images/icon6.gif"/></a>
              <input type="hidden" class="" name="paper_style" value="">
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              试卷状态：
              <select name="paper_status">
                <option value="0" selected="">正常</option>
                <option value="1">禁用</option>
              </select>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              组卷方式：
              <select name="paper_type" id="paper_type_select">
                <option value="1" selected="">选题组卷</option>
                <option value="2">抽题组卷</option>
                <option value="3">随机组卷</option>
              </select>&nbsp;
              <span id="helpIcon" data-toggle="tooltip" data-html="true" data-original-title="选题组卷：从题库手动选择试题组卷&lt;br /&gt;抽题组卷：从题库中随机抽取试题组卷（每个考生试卷内容相同）&lt;br /&gt;随机试卷：由系统随机为考生生成一张试卷（每个考生试卷内容不同）" data-placement="right"><img src="../images/icon_help.gif"></span>
              &nbsp;&nbsp;&nbsp;&nbsp;
              试卷总分：
              <input type="text" style="width:50px;" name="total_score" value="100"/>
              </div>
          </div>
          </div>
          <div class="topSelDiv">
          <div class="title">题型设置</div>
          <ul class="addIconUl">
            <li class="addDanxuanLi" name="1" title="单选"><i class="icon-plus-sign"></i> 单选</li>
            <li class="addDuoxuanLi" name="2" title="多选"><i class="icon-plus-sign"></i> 多选</li>
            <li class="addPanduanLi" name="3" title="判断"><i class="icon-plus-sign"></i> 判断</li>
            <li class="addTiankongLi" name="4" title="填空"><i class="icon-plus-sign"></i> 填空</li>
            <li class="addWendaLi" name="5" title="问答"><i class="icon-plus-sign"></i> 问答</li>
          </ul>
          </div>
          <!--选题组卷-->
          <table class="table table-condensed table-hover customerTab tab1">
            <thead>
              <tr>
                <th>排序</th>
                <th>题型</th>
                <th>数量</th>
                <th class="contentTh">题型标题</th>
                <th>每题分数</th>
                <th>操作</th>
              </tr>
            </thead>
            <tbody class="typeTabBody">
            </tbody>
          </table>
          <!--抽题组卷-->
          <table class="table table-condensed table-hover customerTab tab2" style="display: none;">
            <thead>
              <tr>
                <th>排序</th>
                <th>题型</th>
                <th>数量</th>
                <th class="contentTh">题型标题</th>
                <th>每题分数</th>
                <th>试题分类</th>
                <th>抽取数量</th>
              </tr>
            </thead>
            <tbody class="typeTabBody">
            </tbody>
          </table>
          <!--随机组卷-->
          <table class="table table-condensed table-hover customerTab tab3" style="display: none;">
            <thead>
              <tr>
                <th>排序</th>
                <th>题型</th>
                <th>数量</th>
                <th class="contentTh">题型标题</th>
                <th>每题分数</th>
                <th>试题分类</th>
                <th>抽取数量</th>
              </tr>
            </thead>
            <tbody class="typeTabBody">
            </tbody>
          </table>
          <input type="hidden" class="" name="paper_set_num" value="">
          <p class="buttonP"> 
          <a class="button" href="./SF_files/paper_add.html" id="previewBtn">预览</a>
          <a class="button" href="./SF_files/paper_add.html" id="saveBtn">保存</a>
          <a class="button" href="./SF_files/paper_add.html" id="downloadBtn">下载</a>
        </p>
      </div>
    </div>

<!-- Modal -->
<div id="typeModal" class="modal hide fade iframeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h4 id="myModalLabel">选择分类</h4>
  </div>
  <div class="modal-body">
    <iframe width="100%" height="400px" src="./SF_files/blank_about.html" style="border:0px" name="selTypeModal" id="selTypeModal"></iframe>
  </div>
</div>
<div id="questionsModal" class="modal hide fade iframeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h4 id="myModalLabel">选择试题</h4></div>
  	<div class="modal-body">
        <iframe width="100%" height="400px" src="./SF_files/blank_about.html" style="border:0px" id="selQuestionFrame" name="selQuestionFrame"></iframe>
  </div>
</div>
<div id="questionsModifyModal" class="modal hide fade iframeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
  <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h4 id="myModalLabel">管理试题</h4></div>
  	<div class="modal-body">
        <iframe width="100%" height="400px" src="./SF_files/blank_about.html" style="border:0px" id="modifyQuestionFrame " name="modifyQuestionFrame"></iframe>
  </div>
</div>


<div id="questionsTypeModal" class="modal hide fade iframeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
    <h4 id="myModalLabel">选择试题分类</h4>
  </div>
  <div class="modal-body">
    <iframe width="100%" height="400px" src="./SF_files/blank_about.html" style="border:0px" name="selQuestionsTypeModal" id="selQuestionsTypeModal"></iframe>
  </div>
</div>
<div id="difficultModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
 
    <h4 id="myModalLabel">抽取数量</h4></div>
  <div class="modal-body">
    <iframe width="100%" height="400px" src="./SF_files/paper_add.html" style="border:0px" id="difficultFrame " name="difficultFrame"></iframe>
  </div>
</div>

<div id="jumpDialog" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    <h4 id="myModalLabel" style="text-align:center">提示信息</h4></div>
    <div class="modal-body" style="text-align:center; font-size:16px; height:40px">
    	是否将此试卷立即发布为考试?
  </div>
  <div class="modal-footer">
    <button class="btn" id="jumpToExam" data-dismiss="modal">是</button>
    <button class="btn" id="jumpToUpdate">留在这里</button>
   </div>
</div>
<!-- /container --> 

<script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script> 
<script type="text/javascript" src="../js/bootstrap.js"></script> 

<script type="text/javascript">
    (function ($) {
        $(document).ready(function () {
            if ($.isFunction($.bootstrapIE6)) $.bootstrapIE6($(document));
        });
    })(jQuery);
</script> 
<script type="text/javascript" src="../js/admin_main.js"></script> 
<script type="text/javascript" src="../js/admin_addPaper.js"></script>

</asp:Content>

