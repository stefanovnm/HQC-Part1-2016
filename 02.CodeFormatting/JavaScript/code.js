var browserName = navigator.appName;
var addScroll = false;
var pX = 0;
var pY = 0;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) 
		|| (navigator.userAgent.indexOf('MSIE 6')) > 0) {
	addScroll = true;
}

document.onmousemove = mouseMove; 

if (browserName === "Netscape") {
	document.captureEvents(Event.mouseMove);
}

function mouseMove(evn){
	if (browserName === "Netscape") {
		pX = evn.pageX-5;	
		pY = evn.pageY;	
	} else {
		pX = event.x-5;	
		pY = event.y;	
	}
	
	if (browserName === "Netscape") {	
		if (document.layers['ToolTip'].visibility === 'show') {
			PopTip();
		}
	}else {	
		if (document.all['ToolTip'].style.visibility === 'visible') {
			PopTip();
		}
	}
}

function PopTip() {
	var theLayer;
	if (browserName === "Netscape") {	
		theLayer = document.layers['ToolTip']; 
		
		if ((pX+120) > window.innerWidth){	
			pX = window.innerWidth-150;		
		}

		theLayer.left = pX+10; 	
		theLayer.top = pY+15;	
		theLayer.visibility = 'show';	
	} else {
		theLayer = document.all['ToolTip']; 
		
		if (theLayer) {
			pX = event.x-5;
			pY = event.y;		
			if (addScroll) {
				pX = pX+document.body.scrollLeft;
				pY = pY+document.body.scrollTop;			
			}		

			if ((pX+120) > document.body.clientWidth) {
				pX = pX-150;
			}
			
			theLayer.style.pixelLeft = pX+10;
			theLayer.style.pixelTop = pY+15;		
			theLayer.style.visibility = 'visible';
		}	
	}
}

function HideTip() {	
	args = HideTip.arguments;
	
	if (browserName === "Netscape") { 
		document.layers['ToolTip'].visibility = 'hide'; 
	}else { 
		document.all['ToolTip'].style.visibility = 'hidden'; 
	}
}

function HideMenu1() {	
	if (browserName === "Netscape") { 
		document.layers['menu1'].visibility = 'hide'; 
	} else { 
		document.all['menu1'].style.visibility = 'hidden'; 
	}
}

function ShowMenu1(){
	var theLayer = document.all['menu1'];

	if (browserName === "Netscape"){    	 
		theLayer.visibility = 'show';	   
	} else {  
		theLayer.style.visibility = 'visible';   
	}
}

function HideMenu2() {	     
	if (browserName === "Netscape") { 
		document.layers['menu2'].visibility = 'hide'; 
	} else { 
		document.all['menu2'].style.visibility = 'hidden'; 
	} 
} 

function ShowMenu2() {
	var theLayer = document.all['menu2'];

	if (browserName === "Netscape") {    	    
		theLayer.visibility = 'show';	   
	} else {      
		theLayer.style.visibility = 'visible';   
	}
}