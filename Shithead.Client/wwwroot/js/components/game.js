/**
 * Card dropped
 * */
var cardIsNotDropped = true;

/**
 * Initialize draggable
 */
window.initializeDraggable = () => {
    $('.draggable').draggable({
        start: function (event, ui) {
            $(this).css("z-index", 3);
            $(this).parent().closest('div').css("z-index", 3);

            cardIsNotDropped = true;
        },
        stop: function (event, ui) {
            $(this).css("z-index", 2);
            //$(this).parent().closest('div').css("z-index", 2);
            $(this).css({ left: 0, top: 0 });
        }
    });
}

/**
 * Initialize droppable
 */
window.initializeDroppable = () => {
    $('.droppable').droppable({

        drop: function (event, ui) {
            if (cardIsNotDropped) {
                DotNet.invokeMethodAsync("Shithead.Client", "CardDropped", ui.draggable.attr("id"), $(this).attr('id'));
            }

            cardIsNotDropped = false;
        }
    });
}
