<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<HTML xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
<META content="text/html; charset=iso-8859-1" http-equiv=Content-Type>
<meta name="description" content="Worldwide stamps, postcards, first day covers, coins, rings, watches and jewellery for sale. We also buy gold and silver.">
<meta name="keywords" content="stamps,postcards,first day covers,coins,rings,watches,scrap,gold,silver,Aladdin’s,Aladdins,Pedreguer,Spain,preused,pre used,preowned,pre owned,second hand,furniture,antiques,collectables,memorabilia,property,sales,buying,selling,costa blanca,Costa Blanca,jewellery,stamps,home delivery,home collection,delivery,collection,writer,broadcaster,laurie rapier,kris rapier,laurie,kris,rapier,house clearances,clearances,valuations,commission,white goods,electrical goods,gold,silver,watches,rings,DVDs,CDs,videos,rugs,carpets,coffee tables,dinning room tables,tables,chairs,sideboards,display cabinets,cabinets,TV cabinets,wardrobes,washing machines ,tumble dryers,ovens,microwaves,cookers,fridges,freezers,newspapers,pictures,photographs,photos,photographic,art,oils,televisions,tv,DVD players,video recorders,Alicante,Valencia,N332,market,rastro,lamps,lights,games,toys,sport,books,digiboxes,digi boxes,satellite boxes,kitchen,bathroom,bedroom,hall,garage,tools,power tools,garden,garden tools,garden furniture,dinning room,value,bargain,reliable,trustworthy,unusual">
<TITLE>Worldwide stamps, postcards, first day covers, coins, rings, watches and jewellery for sale.</TITLE>
<link type="text/css" href="jquery-ui-1.8.4.custom.css" rel="stylesheet" />	
<script src="jquery.js" type="text/javascript"></script>
<script src="jquery.blockUI.js" type="text/javascript"></script>
<script src="jquery.lettering.js" type="text/javascript"></script>
<script src="jquery-ui.js" type="text/javascript"></script>

<style>
<!--
 /* Font Definitions */
@font-face
	{font-family:Verdana;
	panose-1:2 11 6 4 3 5 4 4 2 4;
	mso-font-charset:0;
	mso-generic-font-family:swiss;
	mso-font-pitch:variable;
	mso-font-signature:536871559 0 0 0 415 0;}
 /* Style Definitions */
p.MsoNormal, li.MsoNormal, div.MsoNormal
	{mso-style-parent:"";
	margin:0cm;
	margin-bottom:.0001pt;
	mso-pagination:widow-orphan;
	font-size:12.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:"Times New Roman";}
h1
	{mso-style-next:Normal;
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	mso-pagination:widow-orphan;
	page-break-after:avoid;
	mso-outline-level:1;
	font-size:8.0pt;
	mso-bidi-font-size:12.0pt;
	font-family:Verdana;
	mso-font-kerning:0pt;}
p.MsoCaption, li.MsoCaption, div.MsoCaption
	{mso-style-next:Normal;
	margin-top:6.0pt;
	margin-right:0cm;
	margin-bottom:6.0pt;
	margin-left:0cm;
	mso-pagination:widow-orphan;
	font-size:10.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:"Times New Roman";
	font-weight:bold;}
p.MsoBodyText, li.MsoBodyText, div.MsoBodyText
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	mso-pagination:widow-orphan;
	font-size:8.0pt;
	mso-bidi-font-size:12.0pt;
	font-family:Verdana;
	mso-fareast-font-family:"Times New Roman";
	mso-bidi-font-family:"Times New Roman";
	font-weight:bold;}
p.MsoBodyText2, li.MsoBodyText2, div.MsoBodyText2
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	mso-pagination:widow-orphan;
	font-size:22.0pt;
	mso-bidi-font-size:12.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:"Times New Roman";
	color:white;
	font-weight:bold;}
p.MsoBodyText3, li.MsoBodyText3, div.MsoBodyText3
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	mso-pagination:widow-orphan;
	font-size:20.0pt;
	mso-bidi-font-size:12.0pt;
	font-family:"Times New Roman";
	mso-fareast-font-family:"Times New Roman";
	color:white;}
@page Section1
	{size:595.3pt 841.9pt;
	margin:72.0pt 90.0pt 72.0pt 90.0pt;
	mso-header-margin:35.4pt;
	mso-footer-margin:35.4pt;
	mso-paper-source:0;}
div.Section1
	{page:Section1;}
-->
</style>
	
<?
	$jewimages = "";
	$jewdescriptions = "";
	$jewimageratios = "";
	$handle = @fopen("jew.dat", "r");
	if ($handle) {
		$buffer = fgets($handle);
		while (!feof($handle)) {
			$buffer = fgets($handle);
			if (strlen($buffer) != 0 ) {
				list($jewimage,$jewimageratio,$jewdesc,$jewprice,$jewsold) = split(":",$buffer);
				$sep = "";
				if (strlen($jewimages) != 0) {$sep=",";}
				$jewimages = $jewimages . "$sep'$jewimage'";
				$jewimageratios = $jewimageratios . "$sep'$jewimageratio'";
				$sym="";
				if ($jewprice != 0) {$sym="€";} else {$jewprice="";}
				$jewdescriptions = $jewdescriptions . "$sep'$jewdesc $jewprice" . $sym . "<br>$jewsold<br>'";
			}
		}
		fclose($handle);
	}

	$stampimages = "";
	$stampdescriptions = "";
	$stampimageratios = "";
	$handle = @fopen("stamps.dat", "r");
	if ($handle) {
		$buffer = fgets($handle);
		while (!feof($handle)) {
			$buffer = fgets($handle);
			if (strlen($buffer) != 0 ) {
				list($stampimage,$stampimageratio,$stampdesc,$stampprice,$stampsold) = split(":",$buffer);
				$sep = "";
				if (strlen($stampimages) != 0) {$sep=",";}
				$stampimages = $stampimages . "$sep'$stampimage'";
				$stampimageratios = $stampimageratios . "$sep'$stampimageratio'";
				$sym="";
				if ($stampprice != 0) {$sym="€";} else {$stampprice="";}
				$stampdescriptions = $stampdescriptions . "$sep'$stampdesc $stampprice" . $sym . "<br>$stampsold<br>'";
			}
		}
		fclose($handle);
	}
?>

<script type="text/javascript">
	var clockTick;
	var currentSlide;
	var stampFiles = new Array(<?print("$stampimages");?>);
	var stampRatios = new Array(<?print("$stampimageratios");?>);
	var stampDescriptions = new Array(<?print("$stampdescriptions");?>);
	var jewFiles = new Array(<?print("$jewimages");?>);
	var jewRatios = new Array(<?print("$jewimageratios");?>);
	var jewDescriptions = new Array(<?print("$jewdescriptions");?>);

	$(document).ready(function() {
	
		$(".slidelarge1").click(function() {
			$.blockUI({ 
				message: $('#htmlcode1'),
				css: {
					top: '80px',
					left: '290px'
				},
				onBlock: function() {}
 			});
			document.images["blockuipicture1"].src = "stamp_images/" + stampFiles[currentSlide];
			$('.blockOverlay').click($.unblockUI);		
		});
		$(".slidelarge2").click(function() {
			$.blockUI({ 
				message: $('#htmlcode2'),
				css: {
					top: '80px',
					left: '290px'
				},
				onBlock: function() {}
 			});
			document.images["blockuipicture2"].src = "jew_images/" + jewFiles[currentSlide];
			$('.blockOverlay').click($.unblockUI);		
		});
		$(".slidelarge3").click(function() {
			$.blockUI({ 
				message: $('#htmlcode3'),
				css: {
					top: '80px',
					left: '290px'
				},
				onBlock: function() {}
 			});
			document.images["blockuipicture3"].src = "stamp_images/" + stampFiles[currentSlide+1];
			$('.blockOverlay').click($.unblockUI);		
		});
		$(".slidelarge4").click(function() {
			$.blockUI({ 
				message: $('#htmlcode4'),
				css: {
					top: '80px',
					left: '290px'
				},
				onBlock: function() {}
 			});
			document.images["blockuipicture4"].src = "jew_images/" + jewFiles[currentSlide+1];
			$('.blockOverlay').click($.unblockUI);		
		});
	});
	
	function pageLoad() {
		currentSlide = 0;
		displaySlide();
		//clockTick = setInterval("tick()",10000);
	}
	function pageUnload() {
		//clearInterval(clockTick);
	}
	function displaySlide() {
		document.images["aladdinsslide1"].src = "stamp_images/" + stampFiles[currentSlide];
		document.images["aladdinsslide2"].src = "jew_images/" + jewFiles[currentSlide];
		document.images["aladdinsslide3"].src = "stamp_images/" + stampFiles[currentSlide+1];
		document.images["aladdinsslide4"].src = "jew_images/" + jewFiles[currentSlide+1];
		
		document.images["aladdinsslide1"].width=300;
		document.images["aladdinsslide2"].width=300;
		document.images["aladdinsslide3"].width=300;
		document.images["aladdinsslide4"].width=300;
		if (jewRatios[currentSlide] == 1) {document.images["aladdinsslide2"].width=187;}
		if (jewRatios[currentSlide+1] == 1) {document.images["aladdinsslide4"].width=187;}
		if (stampRatios[currentSlide] == 1) {document.images["aladdinsslide1"].width=187;}
		if (stampRatios[currentSlide+1] == 1) {document.images["aladdinsslide3"].width=187;}

		slidetexts();
	}
	function nextSlide() {
		currentSlide = currentSlide + 2;
		if (currentSlide == stampFiles.length) {currentSlide = stampFiles.length-2;}
		displaySlide();
	}
	function prevSlide() {
		currentSlide = currentSlide - 2;
		if (currentSlide < 0) {currentSlide = 0;}
		displaySlide();
	}
	function firstSlide() {
		currentSlide = 0;
		displaySlide();
	}
	function lastSlide() {
		currentSlide = stampFiles.length - 2;
		displaySlide();
	}
	function tick() {
		currentSlide = currentSlide + 2;
		if (currentSlide == stampFiles.length) {currentSlide = 0;}
		displaySlide();
	}
	function slidetexts() {
		document.all.slide1text.innerHTML = "<b>" + stampDescriptions[currentSlide] + "</b>";
		document.all.slide2text.innerHTML = "<b>" + jewDescriptions[currentSlide] + "</b>";
		document.all.slide3text.innerHTML = "<b>" + stampDescriptions[currentSlide + 1] + "</b>";
		document.all.slide4text.innerHTML = "<b>" + jewDescriptions[currentSlide + 1] + "</b>";
	}
	function large1() {
	}
	function large2() {
	}
	function large3() {
	}
	function large4() {
	}
</script>
<style type="text/css">
	ul#icons {margin: 0; padding: 0;}
	ul#icons li {margin: 2px; position: relative; padding: 4px 0; cursor: pointer; float: left;  list-style: none;}
	ul#icons span.ui-icon {float: left; margin: 0 4px;}
</style>	
</head>
<body  bgcolor='green' onLoad="pageLoad()" onunload="pageUnload()">

<div id=htmlcode1 style='DISPLAY: none'>
<img src='slide.jpg' width=450 height=350 name="blockuipicture1" border=0>
<script>large1();</script>
</div>
<div id=htmlcode2 style='DISPLAY: none'>
<img src='slide.jpg' width=450 height=350 name="blockuipicture2" border=0>
<script>large2();</script>
</div>
<div id=htmlcode3 style='DISPLAY: none'>
<img src='slide.jpg' width=450 height=350 name="blockuipicture3" border=0>
<script>large3();</script>
</div>
<div id=htmlcode4 style='DISPLAY: none'>
<img src='slide.jpg' width=450 height=350 name="blockuipicture4" border=0>
<script>large4();</script>
</div>

<div align=center>

<table border=1 cellspacing=0 cellpadding=0 bgcolor="#03ff01" style='background:
 #03FF01;border-collapse:collapse;border:none;mso-border-alt:solid green 6.0pt;
 mso-padding-alt:0cm 5.4pt 0cm 5.4pt'>
 <tr style='height:155.6pt'>
  <td width=284 style='width:213.25pt;border:solid green 6.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:155.6pt'>
  <p class=MsoTitle><b><span style='font-size:36.0pt;mso-bidi-font-size:12.0pt;
  font-family:"Times New Roman";color:purple'><img width=217 height=238
  src="stamphead.jpg" v:shapes="_x0000_i1025"><o:p></o:p></span></b></p>
  </td>
  <td width=406 valign=top style='width:304.75pt;border:solid green 6.0pt;
  border-left:none;mso-border-left-alt:solid green 6.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:155.6pt'>
  <p class=MsoNormal align=center style='text-align:center'><b><span style='font-size:36.0pt;mso-bidi-font-size:12.0pt;
  font-family:"Times New Roman";color:maroon'>WORLD STAMPS<o:p></o:p></span></b></p>
  <p class=MsoNormal align=center style='text-align:center'><b><span
  style='font-size:36.0pt;mso-bidi-font-size:12.0pt;color:maroon'>&amp;<span
  style="mso-spacerun: yes">  </span><o:p></o:p></span></b></p>
  <p class=MsoNormal align=center style='text-align:center'><b><span
  style='font-size:36.0pt;mso-bidi-font-size:12.0pt;color:maroon'>QUALITY<o:p></o:p></span></b></p>
  <p class=MsoNormal align=center style='text-align:center'><b><span
  style='font-size:36.0pt;mso-bidi-font-size:12.0pt;color:maroon'>PRE-OWNED
  JEWELLERY DEALS</span></b><b><span style='font-size:36.0pt;mso-bidi-font-size:
  12.0pt'><o:p></o:p></span></b></p>
  </td>
  <td width=284 style='width:213.25pt;border:solid green 6.0pt;border-left:
  none;mso-border-left-alt:solid green 6.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:155.6pt'>
  <p class=MsoTitle><b><span style='font-size:36.0pt;mso-bidi-font-size:12.0pt;
  font-family:"Times New Roman";color:purple'><img width=222 height=238
  src="jewhead.jpg" v:shapes="_x0000_i1026"><o:p></o:p></span></b></p>
  </td>
 </tr>
</table>

</div>

<p class=MsoNormal align=center style='text-align:center'><span
style='font-size:10.0pt;mso-bidi-font-size:12.0pt;font-family:Verdana'><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></span></p>

<div align=center>

<table border=1 cellspacing=0 cellpadding=0 bgcolor="#03ff01" style='background:
 #03FF01;border-collapse:collapse;border:none;mso-border-alt:solid green 6.0pt;
 mso-padding-alt:0cm 5.4pt 0cm 5.4pt'>
 <tr style='height:120.9pt'>
  <td width=836 valign=top style='width:627.15pt;border:solid green 6.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:120.9pt'>
  <p class=MsoNormal align=center style='text-align:center'><b><span
  style='font-size:20.0pt;mso-bidi-font-size:12.0pt'><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></span></b></p>
  <p class=MsoBodyText3><span style='color:black'>FOLLOWING JUST AN <span style='color:red'><i>“EXAMPLE”</i></span>
  OF MOST RECENT ITEMS TO GO ON DISPLAY AT ALADDIN’S, MANY OTHER BARGAINS
  ALWAYS STOCKED.<o:p></o:p></span></p>
  <p class=MsoNormal><span style='font-size:18.0pt;mso-bidi-font-size:12.0pt'><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></span></p>
  <center><font color='red'>
<b><span style='font-size:24.0pt;mso-bidi-font-size:12.0pt'>NO GIMMICKS – JUST STRAIGHT <o:p></o:p></span></b>
  <b><span style='font-size:24.0pt;mso-bidi-font-size:12.0pt'>FORWARD HONEST TRADING<o:p></o:p></span></b>
  </font></center><br>
<p class=MsoBodyText align=center style='text-align:center'><b><span style='font-size:16.0pt;mso-bidi-font-size:10.0pt;color:white;font-style:
  normal'>DON’T MISS OUT - IF YOU CAN’T GET INTO ALADDIN’S USE OUR <o:p></o:p></span></b></p>
  <p class=MsoBodyText align=center style='text-align:center'><b><span
  style='font-size:16.0pt;mso-bidi-font-size:10.0pt;color:white;font-style:
  normal'>PAY PAL FACILITIES TO SECURE WITH A DEPOSIT, OR BUY…<o:p></o:p></span></b></p>
  
  <p class=MsoBodyText align=center style='text-align:center'><b><![if !supportEmptyParas]>&nbsp;<![endif]><o:p></o:p></b></p>
</div>
<center><img width=552 height=210 src="haggle.jpg"></center><br>
<center><b>Click on slide to show enlarged versions</b></center>
<table align="center" valign="middle" width="75%" frame="box" border=3>
<tr  align="center" valign="middle" style='height:4.0cm'>
<td>
<a class="slidelarge1"><img width=300 height=220 name="aladdinsslide1" border=0></a>
<center><p id=slide1text><</p></center>
</td><td>
<a class="slidelarge2"><img width=300 height=220 name="aladdinsslide2" border=0></a>
<center><p id=slide2text></p></center>
</td></tr>
<tr  align="center" valign="middle" style='height:4.0cm'>
<td>
<a class="slidelarge3"><img width=300 height=220 name="aladdinsslide3" border=0></a>
<center><p id=slide3text></p></center>
</td><td>
<a class="slidelarge4"><img width=300 height=220 name="aladdinsslide4" border=0></a>
<center><p id=slide4text></p></center>
</td></tr>

<tr  align="center" valign="middle"><td colspan=2>
<ul id="icons" >
	<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</li>
	<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</li>
	<li>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</li>
	<li class="ui-state-default ui-corner-all" title="First Slide"><a href="javascript:firstSlide()"><span class="ui-icon ui-icon-seek-first"></span></a></li>
	<li class="ui-state-default ui-corner-all" title="Previous Slide"><a href="javascript:prevSlide()"><span class="ui-icon ui-icon-seek-prev"></span></a></li>
	<li class="ui-state-default ui-corner-all" title="Next Slide"><a href="javascript:nextSlide()"><span class="ui-icon ui-icon-seek-next"></span></a></li>
	<li class="ui-state-default ui-corner-all" title="Last Slide"><a href="javascript:lastSlide()"><span class="ui-icon ui-icon-seek-end"></span></a></li>
</ul>
</td></tr>
</table>
<br><center><a href="index.html" target="_top">Home Page</a></center>
</body>
</html>
