using Microsoft.Playwright;

namespace PlaywrightExample.PageObjects;

public class BasePage {
  private readonly IPage _page;

  public BasePage(IPage page) {
    _page = page;
  }

  public IPage Page => _page;
}