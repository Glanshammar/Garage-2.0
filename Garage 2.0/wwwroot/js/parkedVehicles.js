// wwwroot/js/parkedVehicles.js
function initializeParkedVehicles() {
    // Setup confirmation dialogs for delete
    setupDeleteConfirmation();
    // Initialize real-time updates
    setupRealTimeUpdates();
    // Initialize toast notifications
    setupToastNotifications();
}

function setupDeleteConfirmation() {
    $(document).on('click', '.delete-vehicle', function (e) {
        e.preventDefault();
        const deleteUrl = $(this).attr('href');

        Swal.fire({
            title: 'Are you sure?',
            text: "This vehicle will be checkout from the garage.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Yes, checkout vehicle'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = deleteUrl;
            }
        });
    });
}

function setupRealTimeUpdates() {
    // Update vehicle list every 30 seconds
    setInterval(updateVehicleList, 30000);

    // Update immediately after operations
    $(document).on('vehicle-modified', updateVehicleList);
}

function updateVehicleList() {
    const currentSort = $('#vehicleList').data('current-sort');

    $.get(`/ParkedVehicles/Index?sortOrder=${currentSort}`, function (response) {
        const newContent = $(response).find('#vehicleList').html();
        $('#vehicleList').html(newContent);
    });
}

function setupToastNotifications() {
    // Show toast for success messages
    if ($('#successMessage').length > 0) {
        Toastify({
            text: $('#successMessage').text(),
            duration: 3000,
            gravity: "top",
            position: 'right',
            backgroundColor: "#4caf50"
        }).showToast();
    }

    // Show toast for error messages
    if ($('#errorMessage').length > 0) {
        Toastify({
            text: $('#errorMessage').text(),
            duration: 3000,
            gravity: "top",
            position: 'right',
            backgroundColor: "#f44336"
        }).showToast();
    }
}

// Initialize when document is ready
$(document).ready(initializeParkedVehicles);