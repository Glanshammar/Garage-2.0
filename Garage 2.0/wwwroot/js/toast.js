// ~/wwwroot/js/toast.js
function showToast(message, type = 'success') {
    // Create toast container if it doesn't exist
    let container = document.querySelector('.toast-container');
    if (!container) {
        container = document.createElement('div');
        container.className = 'toast-container';
        document.body.appendChild(container);
    }

    // Create toast element
    const toast = document.createElement('div');
    toast.className = `toast ${type}`;
    toast.textContent = message;

    // Add toast to container
    container.appendChild(toast);

    // Show toast
    setTimeout(() => toast.classList.add('show'), 100);

    // Remove toast after 3 seconds
    setTimeout(() => {
        toast.classList.remove('show');
        setTimeout(() => {
            container.removeChild(toast);
        }, 500);
    }, 3000);
}

// Function to handle TempData messages on page load
document.addEventListener('DOMContentLoaded', function () {
    // Check for success message
    const successMessage = document.querySelector('.alert-success');
    if (successMessage) {
        showToast(successMessage.textContent.trim(), 'success');
        successMessage.remove();
    }

    // Check for error message
    const errorMessage = document.querySelector('.alert-danger');
    if (errorMessage) {
        showToast(errorMessage.textContent.trim(), 'error');
        errorMessage.remove();
    }
});