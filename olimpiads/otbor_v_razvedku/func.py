import math


def func(N):
    k_2 = int(math.log(N, 2))

    return min(abs(2 ** k_2 - N), abs(2 ** (k_2 + 1) - N))
