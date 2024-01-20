def func(packets):
    ms = []
    for _ in range(len(packets)):
        X1, Y1, Z1, X2, Y2, Z2, C1, C2 = packets[_]
        S1 = X1 * Y1 * 2 + X1 * Z1 * 2 + Y1 * Z1 * 2
        V1 = X1 * Y1 * Z1 / 1000
        S2 = X2 * Y2 * 2 + X2 * Z2 * 2 + Y2 * Z2 * 2
        V2 = X2 * Y2 * Z2 / 1000
        m = abs(C1 * S2 - C2 * S1) / abs(V1 * S2 - V2 * S1)
        ms.append(m)
    max_m = min(ms)
    return [float(ms.index(max_m) + 1), round(max_m, 2)]