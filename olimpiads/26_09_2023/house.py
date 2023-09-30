def build_house(X, Y, L, C1, C2, C3, C4, C5, C6):
    out = 0
    itog = 0
    P = (X + Y) * 2

    if (L > P):
        out = L - P
        P = 0
    else:
        P -= L
    if (C1 > C2 + C3):
        itog += (C2 + C3) * (L - out)
        L = 0
    elif (C1 > C2 + C6 + C4 + C5):
        itog += (C2 + C6 + C4 + C5) * (L - out)
        L = 0
    else:
        if (L < min(X, Y)):
            itog += C1 * L
            L = 0
        else:
            itog += C1 * max(X, Y)
            L -= max(X, Y)
    if (C2 + C3 > C2 + C6 + C4 + C5):
        if L > 0:
            itog += (C2 + C6 + C4 + C5) * (L - out)
        L = 0

    if L > 0:
        itog += (C2 + C3) * (L - out)
    itog += P * (C4 + C5)
    itog += out * (C2 + C6)
    return itog