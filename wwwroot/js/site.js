// ===== FUTURISTIC CLIDESCUSTOMS JAVASCRIPT =====

// Wait for DOM to be ready
document.addEventListener('DOMContentLoaded', function() {
    // Initialize all futuristic features
    initParticleSystem();
    initScrollAnimations();
    initCardHoverEffects();
    initFormEnhancements();
    initNavigationEffects();
    initLoadingAnimations();
});

// Particle System for Background
function initParticleSystem() {
    const heroSection = document.querySelector('.futuristic-hero');
    if (!heroSection) return;

    // Create additional particles dynamically
    for (let i = 0; i < 10; i++) {
        const particle = document.createElement('div');
        particle.className = 'particle';
        particle.style.left = Math.random() * 100 + '%';
        particle.style.top = Math.random() * 100 + '%';
        particle.style.animationDelay = Math.random() * 10 + 's';
        particle.style.animationDuration = (Math.random() * 10 + 10) + 's';
        heroSection.querySelector('.hero-particles').appendChild(particle);
    }
}

// Scroll Animations
function initScrollAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('fade-in');
                
                // Add staggered animation for cards
                if (entry.target.classList.contains('futuristic-card')) {
                    const cards = entry.target.parentElement.querySelectorAll('.futuristic-card');
                    cards.forEach((card, index) => {
                        setTimeout(() => {
                            card.style.opacity = '1';
                            card.style.transform = 'translateY(0)';
                        }, index * 100);
                    });
                }
            }
        });
    }, observerOptions);

    // Observe all cards and sections
    document.querySelectorAll('.futuristic-card, .featured-section').forEach(el => {
        observer.observe(el);
    });
}

// Enhanced Card Hover Effects
function initCardHoverEffects() {
    document.querySelectorAll('.futuristic-card').forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-15px) scale(1.02)';
            this.style.boxShadow = '0 25px 50px rgba(102, 126, 234, 0.4)';
            
            // Add glow effect
            const glow = document.createElement('div');
            glow.className = 'card-glow-effect';
            glow.style.cssText = `
                position: absolute;
                top: -10px;
                left: -10px;
                right: -10px;
                bottom: -10px;
                background: linear-gradient(135deg, #667eea, #764ba2);
                border-radius: 25px;
                opacity: 0.3;
                filter: blur(15px);
                z-index: -1;
                pointer-events: none;
            `;
            this.appendChild(glow);
        });

        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0) scale(1)';
            this.style.boxShadow = '0 10px 30px rgba(102, 126, 234, 0.2)';
            
            // Remove glow effect
            const glow = this.querySelector('.card-glow-effect');
            if (glow) glow.remove();
        });
    });
}

// Form Enhancements
function initFormEnhancements() {
    // Add floating labels effect
    document.querySelectorAll('.form-control').forEach(input => {
        input.addEventListener('focus', function() {
            this.parentElement.classList.add('focused');
        });

        input.addEventListener('blur', function() {
            if (!this.value) {
                this.parentElement.classList.remove('focused');
            }
        });

        // Add ripple effect on click
        input.addEventListener('click', function(e) {
            const ripple = document.createElement('span');
            const rect = this.getBoundingClientRect();
            const size = Math.max(rect.width, rect.height);
            const x = e.clientX - rect.left - size / 2;
            const y = e.clientY - rect.top - size / 2;
            
            ripple.style.cssText = `
                position: absolute;
                width: ${size}px;
                height: ${size}px;
                left: ${x}px;
                top: ${y}px;
                background: rgba(102, 126, 234, 0.3);
                border-radius: 50%;
                transform: scale(0);
                animation: ripple 0.6s linear;
                pointer-events: none;
            `;
            
            this.style.position = 'relative';
            this.style.overflow = 'hidden';
            this.appendChild(ripple);
            
            setTimeout(() => ripple.remove(), 600);
        });
    });

    // Add CSS for ripple animation
    const style = document.createElement('style');
    style.textContent = `
        @keyframes ripple {
            to {
                transform: scale(4);
                opacity: 0;
            }
        }
    `;
    document.head.appendChild(style);
}

// Navigation Effects
function initNavigationEffects() {
    const nav = document.querySelector('.futuristic-header');
    const navLinks = document.querySelectorAll('.futuristic-nav .nav-link');
    
    // Add scroll effect to navigation
    window.addEventListener('scroll', () => {
        if (window.scrollY > 100) {
            nav.style.background = 'rgba(0, 0, 0, 0.8)';
            nav.style.backdropFilter = 'blur(30px)';
        } else {
            nav.style.background = 'rgba(0, 0, 0, 0.3)';
            nav.style.backdropFilter = 'blur(20px)';
        }
    });

    // Add active state to navigation links
    navLinks.forEach(link => {
        link.addEventListener('click', function() {
            navLinks.forEach(l => l.classList.remove('active'));
            this.classList.add('active');
        });
    });
}

// Loading Animations
function initLoadingAnimations() {
    // Add loading animation to buttons
    document.querySelectorAll('.futuristic-btn-primary, .futuristic-btn-secondary, .futuristic-btn-card').forEach(btn => {
        btn.addEventListener('click', function(e) {
            if (this.href && !this.href.includes('#')) {
                // Add loading state
                const originalText = this.innerHTML;
                this.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Loading...';
                this.style.pointerEvents = 'none';
                
                // Reset after a delay (for demo purposes)
                setTimeout(() => {
                    this.innerHTML = originalText;
                    this.style.pointerEvents = 'auto';
                }, 1000);
            }
        });
    });
}

// Utility Functions
function createFloatingElement() {
    const element = document.createElement('div');
    element.style.cssText = `
        position: fixed;
        width: 20px;
        height: 20px;
        background: linear-gradient(135deg, #667eea, #764ba2);
        border-radius: 50%;
        pointer-events: none;
        z-index: 1000;
        animation: floatUp 3s ease-out forwards;
    `;
    
    const style = document.createElement('style');
    style.textContent = `
        @keyframes floatUp {
            0% {
                transform: translateY(0) scale(1);
                opacity: 1;
            }
            100% {
                transform: translateY(-100vh) scale(0);
                opacity: 0;
            }
        }
    `;
    document.head.appendChild(style);
    
    return element;
}

// Add click effects to buttons
document.addEventListener('click', function(e) {
    if (e.target.matches('.futuristic-btn-primary, .futuristic-btn-secondary, .futuristic-btn-card')) {
        const rect = e.target.getBoundingClientRect();
        const floatingElement = createFloatingElement();
        floatingElement.style.left = (rect.left + rect.width / 2) + 'px';
        floatingElement.style.top = (rect.top + rect.height / 2) + 'px';
        document.body.appendChild(floatingElement);
        
        setTimeout(() => floatingElement.remove(), 3000);
    }
});

// Smooth scrolling for anchor links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Add parallax effect to hero section
window.addEventListener('scroll', () => {
    const scrolled = window.pageYOffset;
    const hero = document.querySelector('.futuristic-hero');
    if (hero) {
        const rate = scrolled * -0.5;
        hero.style.transform = `translateY(${rate}px)`;
    }
});

// Add typing effect to hero title
function initTypingEffect() {
    const title = document.querySelector('.hero-title');
    if (!title) return;
    
    const text = title.textContent;
    title.textContent = '';
    title.style.borderRight = '2px solid #00d4ff';
    
    let i = 0;
    const typeWriter = () => {
        if (i < text.length) {
            title.textContent += text.charAt(i);
            i++;
            setTimeout(typeWriter, 100);
        } else {
            title.style.borderRight = 'none';
        }
    };
    
    setTimeout(typeWriter, 1000);
}

// Initialize typing effect
setTimeout(initTypingEffect, 500);
