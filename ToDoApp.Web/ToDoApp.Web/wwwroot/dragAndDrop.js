window.ToDos = {
    allowDrop(ev) {
        ev.preventDefault();
    },
    drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
    },
    drop(ev) {
        ev.preventDefault();
        var data = ev.dataTransfer.getData("text");
        var card = document.getElementById(data);
        var nearestTd = ev.target.closest("td");
        if (nearestTd) {
            nearestTd.appendChild(card);
        }
    }
};