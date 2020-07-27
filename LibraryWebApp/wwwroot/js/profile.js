const serverUrl = "https://localhost:5001/";

function initProfile() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener('load', OnProfileBookReceived);
    xhr.open('GET', serverUrl + 'api/Books/DrawBookToProfile');
    xhr.send();
}


function DeleteBook(book_id) {

    var data = new FormData();
    data.append('book_id', book_id);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', serverUrl + 'api/Books/DeletefromProfile');
    console.log(data)
    xhr.send(data);
    alert("Deleted");
    initProfile();
}


function OnProfileBookReceived() {
    console.log(this.responseText);
    const books = JSON.parse(this.responseText);

    const table = document.getElementById("ProfileBookTable");
    console.log(books);
    while (table.firstChild) {
        table.removeChild(table.firstChild);
    }
    books.forEach(q => {
        var i = 0;
        var row = table.insertRow(i);
        var brand = q.book_Title;
        var width = q.book_Author;
        var length = q.lang;
        var book_id = q.book_id;

        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = document.createElement('td');

        var deleteButton = document.createElement("button");

        deleteButton.innerText = "Delete";
        deleteButton.onclick = function () {
            DeleteBook(book_id);
        }


        cell1.innerHTML = brand;
        cell2.innerHTML = width;
        cell3.innerHTML = length;
        i = i + 1;
        cell4.appendChild(deleteButton);
        row.appendChild(cell4);
    })
}

initProfile();
