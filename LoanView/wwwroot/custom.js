$(function () {
    $("#loantab").on('click', 'tr', function () {
        var currentStage = parseInt(this.children[5].innerHTML.trim());
        var stages = ["#acceptedStage", "#verifiedStage", "#approvedStage", "#fulfillmentStage","#completedStage"]
        for (var count = 0; count < stages.length; count++) {
            if (count < currentStage - 1) {
                $(stages[count]).removeClass("is-complete");
                $(stages[count]).addClass("is-complete");
            } else if (count === currentStage - 1) {
                $(stages[count]).removeClass("is-active");
                $(stages[count]).addClass("is-active");
            } else {
                $(stages[count]).removeClass("is-active");
                $(stages[count]).removeClass("is-complete");
            }
        }      
    });
    (function getData() {
        $.getJSON("api/loan", function (data) {
            var tablecontent = $("#loantab tbody");
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                console.log(data[i]);
                var complete = "❌";
                if (data[i]['isComplete']) {
                    complete = "✅";
                }

                var rowcontent = "<tr>" +
                    "<td>" + data[i]['id'] + "</td>" +
                    "<td>" + data[i]['applicantName'] + "</td>" +
                    "<td>" + data[i]['loanName'] + "</td>" +
                    "<td>" + data[i]['loanStatus'] + "</td>" +
                    "<td>" + complete + "</td>" +
                    '<td style="display: none;">' + data[i]["currentStage"] + "</td>" +
                    "</tr>";
                tablecontent.append(rowcontent);
            }
        
        });
        setTimeout(getData, 15000);
    })();
});

