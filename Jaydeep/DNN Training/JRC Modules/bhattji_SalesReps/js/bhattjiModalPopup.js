         // Add click handlers for buttons to show and hide modal popup on pageLoad
        function ShowModalPopup(popUpUrl,width,height,okScript,cancelScript,popUpTitle) {
        
            if (popUpUrl==null) popUpUrl='about:blank';
            if (popUpTitle==null) popUpTitle='bhattji';
            if (width==null) width=400;
            if (height==null) height=200;
            if (okScript==null) okScript='';
            if (cancelScript==null) cancelScript='';
            
            var tdTitle = document.getElementById("tdTitle");
            tdTitle.innerHTML = popUpTitle;
            
            var tdClose = document.getElementById("tdClose");
            tdClose.innerHTML = '<input type="button" value=" X " style="color:red;font-weight:bold" onclick="HideModalPopup();' + cancelScript + '" />';
            
            var popUpContent = document.getElementById("tdContent");
            popUpContent.innerHTML = '<iframe src="'+ popUpUrl +'" style="width:' + width + 'px;height:' + height + 'px;background-color:transparent;text-align:center;" scrolling="auto" frameborder="0" allowtransparency="true" id="popupFrame" name="popupFrame" width="100%" height="100%" align="center"></iframe>';
          
            var tdButtons = document.getElementById("tdButtons");         
            tdButtons.innerHTML = '<input type="button" value="Ok" onclick="HideModalPopup();' + okScript + '" />';
            tdButtons.innerHTML += '<input type="button" value="Close" onclick="HideModalPopup();' + cancelScript + '" />';
            
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        
        function HideModalPopup() {      
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }
         