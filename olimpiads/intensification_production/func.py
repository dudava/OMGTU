import datetime


def func(date_1, date_2, p):
    date_1 = datetime.datetime.strptime(date_1, "%d.%m.%Y")
    date_2 = datetime.datetime.strptime(date_2, "%d.%m.%Y")
    timedelta = date_2 - date_1 + datetime.timedelta(days=1)
    n = timedelta.days
    S = (2 * p + n - 1) / 2 * n

    return S