<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="MenuViewSys.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<link href="Css/style.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="Js/jquery.1.4.2-min.js"></script>
</head>
<body style="width:auto;height:auto">
    <style type="text/css">
        #wrapper {
            position:absolute;
            z-index:1;
            top:0px;
            bottom:0px;
            left:0px;
            width:100%;
            background:#aaa;
            overflow:hidden;
        }

		.swipe ul {
			-webkit-transition:left 800ms ease-in 0;
			-moz-transition:left 800ms ease-in 0;
			-o-transition:left 800ms ease-in 0;
			-ms-transition:left 800ms ease-in 0;
			transition:left 800ms ease-in 0;
		}

        .fullScreen {
            width:100%;
            height:100%;
        }
	</style>

    <div id="wrapper" >
		<ul id="slider" class="fullScreen">
			<li>
                <div>
                    <div style="height:50%;display:block;">
                        <span>红烧肉</span>
                        <img style="float:right;margin:3% 3% 0px 0px;height:90%;width:45%;" src="Images/推荐1-红烧肉.jpg" />
                    </div>
                    <div style="height:50%;position:absolute;bottom:0px;">
                        <img style="float:left;margin:3% 0px 0px 3%;height:90%;width:120%;" src="Images/推荐2-香辣盆盆虾.jpg" />
                    </div>
                </div> 
                <%--<div style="width:100%;height:50%;">
                    <span>红烧肉</span>
                    <img style="margin:20px 20px 0px 0px;" src="Images/推荐1-红烧肉.jpg" />
                </div>
                <div>
                    <img style="margin:0px 0px 20px 20px" src="Images/推荐2-香辣盆盆虾.jpg" />
                    <span style="">香辣盆盆虾</span>
                </div>--%>
			</li>
			<li><img src="Images/2.jpg" style="width:initial;height:initial"/></li>
			<li><img style="width:inherit;height:inherit" src="Images/3.jpg" alt="" /></li>
			<li><img style="width:inherit;height:inherit"src="Images/4.jpg" alt="" /></li>
		</ul>
	</div>

	<script type="text/javascript" src="js/touchScroll.js"></script>
	<script type="text/javascript" src="Js/touchslider.dev.js"></script>
    <script type="text/javascript">
        var t2 = new TouchSlider({
            id: 'slider',
            auto: false
        });
    </script>

</body>
</html>
