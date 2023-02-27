var xhr = new XMLHttpRequest();
xhr.open("GET", "https://localhost:7016/api/Categories")
xhr.send()

xhr.onload = function () {
    var response = JSON.parse(xhr.response);
    var catDiv = document.getElementById("categoriesDiv");

    for (var item of response) {
        var anchorElement = document.createElement("a");
        anchorElement.innerText = item["name"];
        anchorElement.href = ""
        anchorElement.classList.add("nav-item", "nav-link");
        catDiv.appendChild(anchorElement);
    }
}