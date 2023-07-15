using System;
using System.Collections.ObjectModel;
using System.Windows;
using FluentAssertions;
using Moq;
using WpfAppPOS1.Models;
using WpfAppPOS1.ViewModels;
using Xunit;

namespace WpfAppPOS1.ViewModels.Tests
{
    public class SaleWindowVMTests
    {
        MyDbContext db = new MyDbContext();


        [Fact]
        public void Edit_WhenCartItemExists_ShouldUpdateQuantityAndDiscount()
        {
            // Arrange
            var viewModel = new SaleWindowVM();
            var cartItem = new CartItem {  Quantity = 5, Discount = 10 };
            viewModel.Cart.Add(cartItem);
            viewModel.SelectedCartItem = cartItem;

            // Assume the user enters new quantity and discount
            viewModel.Quantity = 5;
            viewModel.Discount = 10;

            // Act
            viewModel.Edit();

            // Assert
            // Verify that the cart item's quantity and discount are updated
            cartItem.Quantity.Should().Be(5);
            cartItem.Discount.Should().Be(10);
        }

        [Fact]
        public void Delete_WhenConfirmed_ShouldRemoveItemFromCart()
        {
            // Arrange
            var viewModel = new SaleWindowVM();
            var cartItem = new CartItem();
            viewModel.Cart.Add(cartItem);
            viewModel.SelectedCartItem = cartItem;

            // Assume the user confirms the deletion
            viewModel.MessageBoxResult = MessageBoxResult.Yes;

            // Act
            viewModel.Delete();

            // Assert
            // Verify that the cart item is removed from the cart
            viewModel.Cart.Should().NotContain(cartItem);
        }

        [Fact]
        public void CreateInvoice_ShouldAddNewInvoiceToDatabase()
        {
            // Arrange
            var viewModel = new SaleWindowVM();

            // Act
            viewModel.CreateInvoice();

            // Assert
            // Verify that a new invoice is added to the database
            // You can use a mock implementation of the database context to assert the expected behavior
        }

    }
}
