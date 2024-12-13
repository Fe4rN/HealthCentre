<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Health Center</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand" href="/index">HealthCenter</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item"><a class="nav-link" href="/login">Log In</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <header class="bg-primary text-white text-center py-5">
        <div class="container">
            <h1 class="display-4">Welcome to HealthCenter</h1>
            <p class="lead">Your partner in comprehensive healthcare solutions.</p>
            <a href="/login" class="btn btn-light btn-lg mt-3">Get Started</a>
        </div>
    </header>

    <section id="about" class="py-5 bg-light">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6">
                    <h2>About Us</h2>
                    <p class="text-muted">HealthCenter is dedicated to providing top-notch healthcare services to our community. With state-of-the-art facilities and a team of experienced professionals, we ensure the best care for you and your loved ones.</p>
                </div>
                <div class="col-md-6">
                    <img src="./images/healthcare.jpg" alt="Healthcare Center" class="img-fluid rounded">

                </div>
            </div>
        </div>
    </section>

    <section id="services" class="py-5">
        <div class="container">
            <h2 class="text-center mb-4">Our Services</h2>
            <div class="row">
                <div class="col-md-4 text-center">
                    <div class="p-4 border rounded">
                        <h4>Primary Care</h4>
                        <p class="text-muted">Comprehensive check-ups and personalized treatments for all ages.</p>
                    </div>
                </div>
                <div class="col-md-4 text-center">
                    <div class="p-4 border rounded">
                        <h4>Emergency Services</h4>
                        <p class="text-muted">24/7 emergency support to handle critical situations promptly.</p>
                    </div>
                </div>
                <div class="col-md-4 text-center">
                    <div class="p-4 border rounded">
                        <h4>Specialized Clinics</h4>
                        <p class="text-muted">Access to specialists in cardiology, dermatology, pediatrics, and more.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <footer class="text-center py-3 bg-dark text-white">
        <p class="mb-0">&copy; 2024 HealthCenter. All rights reserved.</p>
    </footer>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
