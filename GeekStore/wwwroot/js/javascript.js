$(function(){
    let width=$(window).width();
    
        if(width<700){
            //adv2.hidden = true;
            //adv.hidden = false;
            //alert($(window).width());
            pages.hidden = true;
            pagesMobile.hidden = false;
            bar.hidden = true;
            $(".row").removeClass("sl");
        }
    $(".card-small").mouseover(function(){
      $(this).find(".desc").removeAttr('hidden');
        $(this).find(".desc").css("position", 'absolute');
        $(this).removeClass("card-small");
        $(this).addClass("hgth");
        $(this).mouseout(function(){
            $(this).find(".desc").attr("hidden", "")
            $(this).removeClass("hgth");
            $(this).addClass("card-small");
        });
    });


    $(".open-pr-btn").click(function () {
        $("body").css("overflow", "hidden");
        $(this).parent().find(".order").css("width", "80%");
    });
    $(".cls-pr").click(function () {
        $("body").css("overflow", "visible");
        $(this).parent().css("width", "0px");
    });
    //$(".img").mouseenter(function () {

    //    $(this).stop().animate({ 'width': +this.width + 20 + "px", 'height': +this.height + 20 + "px" }, 500);
    //    $(this).mouseout(function () {

    //        $(this).stop().animate({ 'width': +this.width - 20 + "px", 'height': +this.height - 20 + "px" }, 500);
    //    });
    //});
    
      //$("#cart").click(function(){       
      //  $("#cart-panel").slideToggle(1500);
        
      //});
    
        $("#search").on("keyup", function () {
            let value = $(this).val().toLowerCase();
            
            $("#body tr").filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
  
    $('.phone').mask('+38 (000) 000-00-00');
    
});

function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}