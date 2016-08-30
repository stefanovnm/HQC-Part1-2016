function IsMozillaBrowser() {
var currentWindow= window,
	browser = currentWindow.navigator.appCodeName,
	isMozilla = browser === "Mozilla";

	if(isMozilla) {
		alert("Yes");
	} else {
		alert("No");
	}
}
console.log("test");
IsMozillaBrowser();