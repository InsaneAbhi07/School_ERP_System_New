$(document).ready(function () {
    $('#schoolTable').DataTable({
        pageLength: 5,
        lengthMenu: [5, 10, 25, 50],
        ordering: true,
        responsive: true,
        language: {
            search: "🔍 ",
            searchPlaceholder: "Search...",
            lengthMenu: "Show _MENU_ entries per page",
            paginate: { previous: "Prev", next: "Next" }
        }
    });
});