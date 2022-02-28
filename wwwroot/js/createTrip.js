var directionsService;
var directionsRenderer;

function initMap() {
    
    directionsService = new google.maps.DirectionsService();
    directionsRenderer = new google.maps.DirectionsRenderer({ preserveViewport: true});

    const map = new google.maps.Map(document.getElementById("map"),
        {
            zoom: 6,
            center: { lat: 50.557898, lng: 17.038538 },
            mapTypeId: 'terrain'
        });


    directionsRenderer.setMap(map);

    // Create an info window to share between markers.
    const infoWindow = new google.maps.InfoWindow();

    pointsList.forEach((point, i) => {
        const marker = new google.maps.Marker({
            position: { lat: point.SzerokoscGeo, lng: point.DlugoscGeo },
            map,
            title: `${i + 1}. ${point.Nazwa}`,
            optimized: false,
            icon: {
                path: google.maps.SymbolPath.CIRCLE,
                scale: 5,
                fillColor: "#F00",
                fillOpacity: 1,
                strokeWeight: 0.4
            },
            pointName: point.Nazwa
    });

        // Add a click listener for each marker, and set up the info window.
        marker.addListener("click",
            () => {
                infoWindow.close();
                infoWindow.setContent(marker.getTitle());
                infoWindow.open(marker.getMap(), marker);

                $.ajax({
                    url: "/PlanujWycieczke/GetPartial",
                    data: { pointID: marker.pointName },
                    dataType: 'html',
                    success: function(partialView) {
                        $('#div1').html(partialView);
                    }
                });
            });
    });
}

function calculateAndDisplayTrail(TrailsList) {
    if (TrailsList.length < 1) {
        return;
    }
    var waypts = [];
    const origin = { lat: TrailsList[0].PunktStartowy.SzerokoscGeo, lng: TrailsList[0].PunktStartowy.DlugoscGeo };
    const destination = { lat: TrailsList.at(-1).PunktKoncowy.SzerokoscGeo, lng: TrailsList.at(-1).PunktKoncowy.DlugoscGeo };
    console.log(destination);
    var points = 0;
    for (let i = 0; i < TrailsList.length - 1; i++) {
        var point = TrailsList[i].PunktKoncowy;
        points += TrailsList[i].PunktyZaTrase;
        var loc = { lat: point.SzerokoscGeo, lng: point.DlugoscGeo };
            waypts.push({
                location: loc,
                stopover: false,
            });
    }

    directionsService.route({
            origin: origin,
            destination: destination,
            waypoints: waypts,
            optimizeWaypoints: true,
            travelMode: google.maps.TravelMode.WALKING,
        })
        .then((response) => {
            directionsRenderer.setDirections(response);

            const Trail = response.routes[0];
            const summaryPanel = document.getElementById("summary");

            summaryPanel.innerHTML = "";
            var totalDistance = 0;

            for (let i = 0; i < Trail.legs.length; i++) {
                const Trailsegment = i + 1;
                totalDistance += Trail.legs[i].distance.value;
            }
            summaryPanel.innerHTML += "<p>Punkt początkowy: " + TrailsList[0].PunktStartowy.Nazwa + "</p>";
            summaryPanel.innerHTML += "<p>Punkt końcowy: " + TrailsList.at(-1).PunktKoncowy.Nazwa + "</p>";
            summaryPanel.innerHTML += "<p>Długość: " + totalDistance + "m</p>";
            summaryPanel.innerHTML += "<p>Punkty: " + points + "</p>";
        })
}

