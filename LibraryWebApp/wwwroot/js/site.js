const serverUrl = "https://localhost:5001/";


function OnBookReceived() {
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
       
        var AddButton = document.createElement("button");
        
        
        AddButton.innerText = "Add";
       
        AddButton.onclick = function () {
            AddBookToProfile(book_id);
        }
       
        cell1.innerHTML = brand;
        cell2.innerHTML = width;
        cell3.innerHTML = length;
        i = i + 1;
  
        cell5.appendChild(AddButton);
     
        row.appendChild(cell4);
        row.appendChild(cell5);
        row.appendChild(cell6);
    })
}






function AddBookToProfile(book_id) {
    console.log(book_id)
    var data = new FormData();
    data.append('book_id', book_id);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', serverUrl + 'api/Books/AddBookToProfile');
    xhr.send(data);
    alert("Book added to Your Profile");
    init();
}


    



//function SendfromModal(realbooktitle) {
//    const book_title = document.getElementById("book_title");
//    const book_author = document.getElementById("book_author");
//    const book_genre = document.getElementById("lang");

//    var data = new FormData();
//    data.append('realbooktitle', realbooktitle);
//    data.append('book_title', book_title.value);
//    data.append('book_author', book_author.value);
//    data.append('lang', book_genre.value);


//    var xhr = new XMLHttpRequest();
//    xhr.open('POST', serverUrl + 'api/Books/ModifyBooks');
//    xhr.send(data);
//    console.log(data.realbooktitle);
//    setTimeout(function () { init(); }, 500);
//}

function DeleteBook(book_id) {

    var data = new FormData();
    data.append('book_id', book_id);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', serverUrl + 'api/Books/DeleteBook');
    console.log(data)
    xhr.send(data);
    alert("Deleted");
    init();
}





    function init() {
        const xhr = new XMLHttpRequest();
        xhr.addEventListener('load', OnBookReceived);
        xhr.open('GET', serverUrl + 'api/Books');
        xhr.send();
    }


init();