const serverUrl = "https://localhost:5001/";


function Addinit() {
    const xhr = new XMLHttpRequest();
    xhr.addEventListener('load', AddBookReceived);
    xhr.open('GET', serverUrl + 'api/Books');
    xhr.send();
}

function AddBookReceived() {
    const books = JSON.parse(this.responseText);
    const table = document.getElementById("booktable");
    while (table.firstChild) {
        table.removeChild(table.firstChild);
    }
    books.forEach(q => {
        var i = 0;
        var row = table.insertRow(i);
        var brand = q.book_Title;
        var width = q.book_Author;
        var book_id = q.book_id;
        var length = q.lang;
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        var cell4 = document.createElement('td');
        var cell5 = document.createElement('td');
        var cell6 = document.createElement('td');
        var deleteButton = document.createElement("button");
        var UpdateButton = document.createElement("button");
        UpdateButton.innerText = "Update";
        deleteButton.innerText = "Delete";
        deleteButton.onclick = function () {
            DeleteBook(book_id);
        }

        UpdateButton.onclick = function () {
            OpenModal(brand);
            console.log(brand);
        }
        cell1.innerHTML = brand;
        cell2.innerHTML = width;
        cell3.innerHTML = length;
        i = i + 1;
        cell4.appendChild(deleteButton);
        cell6.appendChild(UpdateButton);
        row.appendChild(cell4);
        row.appendChild(cell5);
        row.appendChild(cell6);
    })
}

function ReceiveBookData() {
    const book_title = document.getElementById("book_title");
    const book_author = document.getElementById("book_author");
    const book_genre = document.getElementById("book_genre");

    var data = new FormData();
    data.append('book_Title', book_title.value);
    data.append('book_author', book_author.value);
    data.append('lang', book_genre.value);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', serverUrl + 'api/Books/UpdateBooks');
    xhr.send(data);
    setTimeout(function () { Addinit(); }, 500);


}

function DeleteBook(book_id) {

    var data = new FormData();
    data.append('book_id', book_id);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', serverUrl + 'api/Books/DeleteBook');
    console.log(data)
    xhr.send(data);
    alert("Deleted");
    Addinit();
}


function OpenModal(realbooktitle) {
    $('#addBoardModal').modal("show");
    console.log(realbooktitle);
    var append = document.getElementById("modal-body");
    while (append.firstChild) {
        append.removeChild(append.firstChild);
    }
    var form = document.createElement('form');
    form.setAttribute("id", "modal-form");
    var input1 = document.createElement('input');
    input1.setAttribute("id", "modalbook_title");
    var input2 = document.createElement('input');
    input2.setAttribute("id", "modalbook_author");
    var input3 = document.createElement('input');
    input3.setAttribute("id", "modalbook_genre");
    append.appendChild(form);
    var submitbutton = document.createElement('button');
    submitbutton.innerText = "Update";
    form.appendChild(input1);
    form.appendChild(input2);
    form.appendChild(input3);
    append.appendChild(input1);
    append.appendChild(input2);
    append.appendChild(input3);
    append.appendChild(submitbutton);

    submitbutton.onclick = function () {

        const book_title = document.getElementById("modalbook_title");
        const book_author = document.getElementById("modalbook_author");
        const book_genre = document.getElementById("modalbook_genre");

        console.log(book_title.value);
        console.log(book_author.value);
        console.log(book_genre.value);
        console.log(realbooktitle);

        var data = new FormData();

        data.append('realbooktitle', realbooktitle);
        data.append('book_title', book_title.value);
        data.append('book_author', book_author.value);
        data.append('lang', book_genre.value);




        var xhr = new XMLHttpRequest();
        xhr.open('POST', serverUrl + 'api/Books/ModifyBooks');
        xhr.send(data);
        setTimeout(function () { Addinit(); }, 500);

    }
}

Addinit();
