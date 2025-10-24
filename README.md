# ClidesCustoms - Premium Car Services & Parts Management System

A comprehensive ASP.NET Core MVC application for managing car services, products, bookings, and orders for ClidesCustoms automotive business.

## Features

### 🚗 **Services Management**
- Add, edit, and manage car services
- Service categories (Maintenance, Custom, Repair)
- Pricing and duration tracking
- Service images and descriptions

### 🛍️ **Products Catalog**
- Product inventory management
- Stock quantity tracking
- Brand and category organization
- Product images and pricing

### 📅 **Booking System**
- Service appointment booking
- Customer vehicle information
- Booking status tracking (Pending, Confirmed, Completed, Cancelled)
- Vehicle details and notes

### 🛒 **Order Management**
- Product order processing
- Customer order history
- Order status tracking
- Shipping and billing addresses

### 👥 **Customer Management**
- Customer registration and profiles
- Contact information management
- Customer order and booking history

## Technology Stack

- **Framework**: ASP.NET Core 9.0 MVC
- **Database**: Entity Framework In-Memory Database
- **ORM**: Entity Framework Core 9.0
- **Frontend**: Bootstrap 5, HTML5, CSS3, JavaScript
- **Styling**: Custom CSS with modern design

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code (optional)
- **No database installation required!**

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd ClidesCustoms
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Open your browser** and navigate to `https://localhost:5001`

That's it! The application uses an in-memory database with pre-seeded data.

## Database Schema

### Core Entities

- **Services**: Car services offered (Oil Change, Custom Paint, etc.)
- **Products**: Parts and accessories for sale
- **Customers**: Customer information and contact details
- **Bookings**: Service appointments with vehicle details
- **Orders**: Product orders with order items
- **OrderItems**: Individual products in orders

### Relationships

- Bookings → Customers (Many-to-One)
- Bookings → Services (Many-to-One)
- Orders → Customers (Many-to-One)
- Orders → OrderItems (One-to-Many)
- OrderItems → Products (Many-to-One)

## Sample Data

The application includes pre-seeded data:

### Services
- Oil Change (R49.99, 30 minutes)
- Custom Paint Job (R1,499.99, 8 hours)
- Brakes Replacement (R299.99, 2 hours)

### Products
- Performance Air Filter (R799.99, RacingLine brand)
- LED Headlight Kit (R399.99, OEM brand)
- Bucket Seats (R1,000.99, Recaro brand)

## Features Overview

### Homepage
- Featured services and products display
- Modern hero section with call-to-action buttons
- Responsive design for all devices

### Services Management
- CRUD operations for services
- Service categorization
- Image support for service visualization
- Duration and pricing management

### Products Management
- Product catalog with images
- Stock quantity tracking
- Brand and category organization
- Pricing management

### Booking System
- Customer service booking
- Vehicle information capture
- Booking status management
- Service scheduling

### Order Processing
- Product order creation
- Customer order management
- Order status tracking
- Shipping and billing management

## UI/UX Features

- **Modern Design**: Clean, professional interface
- **Responsive Layout**: Works on desktop, tablet, and mobile
- **Interactive Elements**: Hover effects and smooth transitions
- **Color Scheme**: Professional blue gradient theme
- **Typography**: Clean, readable fonts
- **Navigation**: Intuitive menu structure

## Development

### Project Structure

```
ClidesCustoms/
├── Controllers/          # MVC Controllers
├── Models/              # Data Models
├── Views/               # Razor Views
├── Data/                # Database Context
├── wwwroot/             # Static Files
└── Properties/          # Configuration
```

### Key Controllers

- `HomeController`: Homepage and featured content
- `ServicesController`: Service management
- `ProductsController`: Product catalog
- `BookingsController`: Service booking system
- `OrdersController`: Order management
- `CustomersController`: Customer management

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## License

This project is licensed under the MIT License.

## Support

For support and questions, please contact the development team.

---

**ClidesCustoms** - Premium automotive services and parts management system.
