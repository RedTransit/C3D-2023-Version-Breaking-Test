# C3D-2023-Version-Breaking-Test
I built a small test code project that simply loads in a Parts List and a list of Surface Styles.
Both use StyleCollectionBase, so this really affects anything that uses that.
There’s no documentation anywhere stating that 2023 API changes would be version breaking and Civil 3D hasn’t had a version breaking API since 2013.

2022 API
https://help.autodesk.com/view/CIV3D/2022/ENU/?guid=GUID-6D41D043-4958-40B7-9C7E-45A6D780955B

PartsListSet is of PartsListCollection
PartsListCollection is of StyleCollectionBase
StyleCollectionBase is of Autodesk.Civil.DatabaseServices.TreeOidWrapper

2023 API (Testing on 2023.2 and greater)
https://help.autodesk.com/view/CIV3D/2023/ENU/?guid=GUID-6D41D043-4958-40B7-9C7E-45A6D780955B
PartsListSet is of PartsListCollection
PartsListCollection is of StyleCollectionBase
StyleCollectionBase is of Autodesk.Civil.DatabaseServices.TreeNodeCollectionBase



To Test, Build the project using 2023.2 references and above and NETLOAD it into Civil 3D 2022 or before. You'll find the error pointing to TreeNodeCollectionBase.
