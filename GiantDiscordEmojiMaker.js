var fs = require('fs');
  var os = require('os'); os.tmpDir = os.tmpdir;
const {clipboard} = require('electron')
//load up HTMLUnit JK u have to use selenium for javascript
var assert = require('assert');
var webdriver = require('selenium-webdriver');
var chrome = require('selenium-webdriver/chrome');
var path = require('chromedriver').path;

var service = new chrome.ServiceBuilder(path).build();
chrome.setDefaultService(service);

var deepfryurl = "https://discordapp.com/channels/498244198701596673/498244198701596675";
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function uploademojis()
{
var driver = new webdriver.Builder()
    //.withCapabilities(chromeCapabilities)
    .withCapabilities(webdriver.Capabilities.chrome())
	//https://stackoverflow.com/questions/46637063/selenium-webdriver-nodejs-equivalent-to-java-code-for-desiredcapabilities
	//.withCapabilities(
	/*{
						'browserName': 'chrome', 
						'name':'Rhodesia', 
						'prefs': {
						"download.default_directory": "C:\\Users\\Velentium\\Desktop\\steven\\dumpster",
						"download.prompt_for_download": false,
						"download.directory_upgrade": true,
						"plugins.plugins_disabled": ["Chrome PDF Viewer"]}
						,'detatch':true
						}*/
	//					options.toCapabilities())
	//https://sites.google.com/a/chromium.org/chromedriver/capabilities
    .build();

	driver.get(deepfryurl);
console.log("waiting for window to open");
	var query = await driver.wait(webdriver.until.elementLocated(webdriver.By.className("file-input")), 300000);
	
	console.log("it opened");
	await driver.findElement(webdriver.By.id("imageLoader")).then(
	async function (pasteToMe) {
		
		pasteToMe.sendKeys(process.argv[2]).then(//clipboard.readText())
		async function (pass1){
			
		},
		async function (err2){
			console.log("failed btw");
			console.log(err2);
		});
	
	}, function (err1){});
}
	
uploademojis()
	
	
	
	
	
	
	
	
	
	
	
	