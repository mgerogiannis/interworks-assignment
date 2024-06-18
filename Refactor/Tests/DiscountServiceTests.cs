using Refactor.Entities;
using Refactor.Interfaces;
using Refactor.Services;
using Xunit;

public class DiscountServiceTests
{
    [Fact]
    public void ApplyDiscounts_ShouldApplyAllDiscountsInOrder()
    {
        // Arrange
        var discounts = new List<IDiscount>
        {
            new PriceListDiscount(5),
            new PromotionDiscount(10),
            new CouponDiscount(10)
        };
        var discountService = new DiscountService(discounts);
        decimal initialAmount = 340m;

        // Act
        var results = discountService.ApplyDiscounts(initialAmount);

        // Assert
        Assert.Equal(3, results.Count);
        Assert.Equal("Price List Discount", results[0].DiscountName);
        Assert.Equal("Promotion Discount", results[1].DiscountName);
        Assert.Equal("Coupon Discount", results[2].DiscountName);

        Assert.Equal(17m, results[0].DiscountAmount);
        Assert.Equal(32.3m, results[1].DiscountAmount);
        Assert.Equal(10m, results[2].DiscountAmount);

        Assert.Equal(323m, results[0].TotalAfterDiscount);
        Assert.Equal(290.7m, results[1].TotalAfterDiscount);
        Assert.Equal(280.7m, results[2].TotalAfterDiscount);
    }
}
