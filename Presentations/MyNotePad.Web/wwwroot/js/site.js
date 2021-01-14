var links = document.querySelectorAll("li.list-group-item");

for (var i = 0; i < links.length; i++) {
    links[i].addEventListener("click", function (e) {
        if (e.target.tagName === "A") {
            var noteTitle = e.target.textContent;

            for (var x = 0; x < notes.length; x++) {
                if (notes[x].NoteTitle === noteTitle) {
                    document.getElementById("text").innerText = notes[x].NoteContent;
                }
            }
        }
    });
}
