function showDate()
{
	// create a new Date object
	var today = new Date();

	// get the current date and time
	var date = today.toLocaleDateString();

	// find the HTML element with the ID "date"
	var element = document.getElementById("date");

	// set the text of the element to the current date
	element.innerHTML = date;

}

function updateActiveNavToHome() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navHome").addClass("active");
}

function updateActiveNavToPlace() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navPlace").addClass("active");
}

function updateActiveNavToTravel() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navTravel").addClass("active");
}

function updateActiveNavToHotel() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navHotel").addClass("active");
}

function updateActiveNavToContact() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navContact").addClass("active");
}

function updateActiveNavToUser() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navUser").addClass("active");
}

function updateActiveNavToAdmin() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navAdmin").addClass("active");
}

function updateActiveNavToFlight() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navFlight").addClass("active");
}

function updateActiveNavToGuide() {
	var activedItem = $("a.active");
	activedItem.removeClass("active");
	$("#navGuide").addClass("active");
}



function navClicked(e) {
	var name = e.target.name;
	alert(name);

}

function openTab(evt, tabName) {
	var i, tabcontent, tablinks;
	tabcontent = document.getElementsByClassName("tabcontent");
	for (i = 0; i < tabcontent.length; i++) {
		tabcontent[i].style.display = "none";
	}
	tablinks = document.getElementsByClassName("tablinks");
	for (i = 0; i < tablinks.length; i++) {
		tablinks[i].className = tablinks[i].className.replace(" active", "");
	}
	document.getElementById(tabName).style.display = "block";
	evt.currentTarget.className += " active";
}